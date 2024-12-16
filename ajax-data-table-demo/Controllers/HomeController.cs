using ajax_data_table_demo.Models;
using AjaxDataTable;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ajax_data_table_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult IndexAjaxList(bool? m, int? page, string sort_by, string sort_direction, string query)
        {
            if (m != null && m.Value)
            {
                List<TableDataColumn> columns =
                [
                    new IndexTableDataColumn(""),
                    new TableDataColumn("id", "ID", "200px", TableDataColumn.Aligns.right, false),
                    new TableDataColumn("name", "Name", null, TableDataColumn.Aligns.left, true),
                    new TableDataColumn("district", "District", "200px", TableDataColumn.Aligns.center, true),
                    new TableDataColumn("country", "Country", "100px", TableDataColumn.Aligns.center, false),
                    new TableDataColumn("population", "Population", "150px", TableDataColumn.Aligns.right, true),
                    new CheckBoxTableDataColumn(""),
                ];

                TableDataModel tmodel = new()
                {
                    columns = [.. columns]
                };

                return Json(columns);
            }

            if (page == null)
                page = 0;
            int pageSize = 20;

            TableDataPage model;

            //int i = page.Value * pageSize + 1;

            var all_rows = (from c in World.Cities select c);
            if (!string.IsNullOrEmpty(query))
            {
                query = query.Trim().ToUpper();

                all_rows = (from c in all_rows
                            where c.Name.ToUpper().Contains(query) || c.District.ToUpper().Contains(query) || c.CountryCode.ToUpper().Contains(query)
                            select c);
            }

            int count = all_rows.Count();
            long totalPopulation = all_rows.Sum(c => c.Population);
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

            return Json(model);

        }
    }
}
