using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDataTable;
using System.Runtime.Caching;

namespace ajax_data_table_test.Controllers
{
    public class HomeController : Controller
    {
        private static MemoryCache cache = MemoryCache.Default;

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bootstrap()
        {
            return View();
        }

        public JsonResult IndexAjaxList(bool? m, int? page, string sort_by, string sort_direction, string query)
        {
            if (m != null && m.Value)
            {
                List<TableDataColumn> columns = new List<TableDataColumn>();
                columns.Add(new IndexTableDataColumn(""));
                columns.Add(new TableDataColumn("id", "ID", "200px", TableDataColumn.Aligns.right, false));
                columns.Add(new TableDataColumn("name", "Name", null, TableDataColumn.Aligns.left, true));
                columns.Add(new TableDataColumn("district", "District", "200px", TableDataColumn.Aligns.center, true));
                columns.Add(new TableDataColumn("country", "Country", "100px", TableDataColumn.Aligns.center, false));
                columns.Add(new TableDataColumn("population", "Population", "150px", TableDataColumn.Aligns.right, true));
                columns.Add(new CheckBoxTableDataColumn(""));

                TableDataModel tmodel = new TableDataModel()
                {
                    columns = columns.ToArray()
                };

                return Json(columns, JsonRequestBehavior.AllowGet);
            }

            if (page == null)
                page = 0;
            int pageSize = 20;

            string cache_key = string.Format("{0}#{1}#{2}#{3}", page, sort_by, sort_direction, query);
            TableDataPage model = cache[cache_key] as TableDataPage;
            if (model != null)
            {
                return Json(model);
            }

            using (var context = new WorldEntities())
            {
                //int i = page.Value * pageSize + 1;

                var all_rows = (from c in context.Cities select c);
                if (!string.IsNullOrEmpty(query))
                {
                    query = query.Trim().ToUpper();

                    all_rows = (from c in all_rows
                                where c.Name.ToUpper().Contains(query) || c.District.ToUpper().Contains(query) || c.CountryCode.ToUpper().Contains(query)
                                select c);
                }

                int count = all_rows.Count();
                long totalPopulation = all_rows.Sum(c => c.Population.Value);
                model = new TableDataPage() { current_page = page.Value, total_page = (count / pageSize + (count % pageSize > 0 ? 1 : 0)), page_size = pageSize, total = count };

                if (sort_direction != "a")
                    sort_direction = "d";

                if (sort_by == "population")
                {
                    if (sort_direction == "d")
                        all_rows = all_rows.OrderByDescending(r => r.Population);
                    else
                        all_rows = all_rows.OrderBy(r => r.Population);
                }
                else if (sort_by == "district")
                {
                    if (sort_direction == "d")
                        all_rows = all_rows.OrderByDescending(r => r.District);
                    else
                        all_rows = all_rows.OrderBy(r => r.District);
                }
                else if (sort_by == "country")
                {
                    if (sort_direction == "d")
                        all_rows = all_rows.OrderByDescending(r => r.CountryCode);
                    else
                        all_rows = all_rows.OrderBy(r => r.CountryCode);
                }
                else 
                {
                    if (sort_direction == "d")
                        all_rows = all_rows.OrderByDescending(r => r.Name);
                    else
                        all_rows = all_rows.OrderBy(r => r.Name);

                    sort_by = "name";
                }

                model.sort_by = sort_by;
                model.sort_direction = sort_direction;

                var paged_rows = all_rows.Skip(pageSize * page.Value).Take(pageSize).ToList();
                model.summary = new { population = totalPopulation };
                model.data = (from r in paged_rows select new { id = r.ID, name = r.Name, population = r.Population, district = r.District, country = r.CountryCode });

                cache.Set(cache_key, model, new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(15) });

                return Json(model, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
