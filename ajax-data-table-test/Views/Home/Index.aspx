<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Cities in the world</title>

<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-82747515-1', 'auto');
  ga('send', 'pageview');

</script>

    <%: Styles.Render("~/Content/css") %>
    <link href="<%: Url.Content("~/Content/ajax-data-table.css") %>" rel="stylesheet" type="text/css" />

    <%: Scripts.Render("~/bundles/jquery") %>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/ajax-data-table.js") %>"></script>

    <link href="<%: Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/bootstrap.min.js") %>"></script>

    <script src="https://use.fontawesome.com/f4453be940.js"></script>
    
        <script type="text/javascript">
        $(function () {
            AjaxDataTable.render($("#city-list2"),
                {
                    width: "100%",

                    onQuery: function () {
                        return { query: $("#query").val() };
                    },

                    cellRenderer: function (column_model, table_data, row_index) {
                        return AjaxDataTable.defaultCellRenderer(column_model, table_data, row_index);
                    },

                    onCellClicked: function (column_model, table_data, row_index) {
                        console.log("List 2: " + JSON.stringify(table_data.data[row_index]));
                    },

                    onHeaderClicked: function (column_model, table_data) {
                        //alert(JSON.stringify(column_model.name));
                        return true;
                    },

                    onLoaded: function () {
                        console.log("List 2 loaded");
                    },

                    page: 1 //page index is started at 0
                }
            );

            AjaxDataTable.render("#city-list3",
                {
                    width: "50%",

                    onQuery: function () {
                        return { query: $("#query").val() };
                    },

                    onCellClicked: function (column_model, table_data, row_index) {
                        console.log("List 3: " + JSON.stringify(table_data.data[row_index]));
                    },

                    onLoaded: function () {
                        console.log("List 3 loaded");
                    }
                }
            );

            AjaxDataTable.render($("#local-data-list"),
                {
                    width: "80%",

                    onCellClicked: function (column_model, table_data, row_index) {
                        console.log("Local data list: " + JSON.stringify(table_data.data[row_index]));
                    },

                    onLoaded: function () {
                        console.log("Local data list loaded");
                    },

                    modelProvider: function (url, onsuccess, onerror) {
                        if (!$.isFunction(onsuccess)) {
                            return;
                        }

                        var table_model = [{ "name": "_index", "title": "", "type": "index", "width": "30px", "align": "center", "sorting_enabled": false, "visible": true }, { "name": "id", "title": "ID", "type": "text", "width": "200px", "align": "right", "sorting_enabled": false, "visible": true }, { "name": "name", "title": "Name", "type": "text", "width": null, "align": "left", "sorting_enabled": true, "visible": true }, { "name": "district", "title": "District", "type": "text", "width": "200px", "align": "center", "sorting_enabled": true, "visible": true }, { "name": "country", "title": "Country", "type": "text", "width": "100px", "align": "center", "sorting_enabled": false, "visible": true }, { "name": "population", "title": "Population", "type": "text", "width": "150px", "align": "right", "sorting_enabled": true, "visible": true }, { "name": "_check", "title": "", "type": "check", "width": "60px", "align": "center", "sorting_enabled": false, "visible": true }];

                        onsuccess(table_model);
                    },

                    dataProvider: function (url, params, onsuccess, onerror) {
                        if (!$.isFunction(onsuccess)) {
                            return;
                        }

                        var table_data = { "data": [{ "id": 698, "name": "[San Cristóbal de] la Laguna", "population": 127945, "district": "Canary Islands", "country": "ESP" }], "current_page": 0, "total_page": 1, "page_size": 20, "total": 1, "sort_by": "name", "sort_direction": "a", "summary": { "population": 0 } };
                        onsuccess(table_data);
                    }
                }
            );

            AjaxDataTable.render("#city-list4",
    {
        onQuery: function () {
            return { query: $("#query").val() };
        },

        bulkActions: bulkActions = [{
            title: "Sum: population (with circle icon)", handler: function (rows) {
                if (rows.length == 0)
                    return;

                var sum = 0;
                for (var i = 0; i < rows.length; i++) {
                    sum += rows[i].population;
                }

                alert("SUM: " + sum);
            },
            icon: 'circle-o'
        },
                {
                    title: "MAX: population", handler: function (rows) {
                        if (rows.length == 0)
                            return;

                        var max = 0;
                        for (var i = 0; i < rows.length; i++) {
                            if (max < rows[i].population)
                                max = rows[i].population;
                        }

                        alert("MAX: " + max);
                    }
                }
        ],

        onCellClicked: function (column_model, table_data, row_index) {
            console.log("List 4: " + JSON.stringify(table_data.data[row_index]));
        },
        onLoaded: function () {
            console.log("List 4 loaded");
        },
        groupBulkActionButton: true
    }
);
        });
    </script>
</head>
<body>
    <div class="container">
        <h1>ajax-data-table</h1>
        <p>Please install Nuget package at https://www.nuget.org/packages/ajax-data-table/ to your project</p>
        <div>
            Filter:
        <input id="query" /><input type="button" onclick="AjaxDataTable.render($('.sample-list'), 'refresh'); event.preventDefault();" value="Filter" />

            <h2>This table is loaded without any javascript function call</h2>
            <a id="city-list1" href="<%: Url.Action("IndexAjaxList", "Home") %>" class="sample-list ajax-data-table"></a>
            <br style="clear: both;" />
            <hr />

            <h2>This table is loaded at page 2 by default</h2>
            <a id="city-list2" href="<%: Url.Action("IndexAjaxList", "Home") %>" class="sample-list"></a>
            <br style="clear: both;" />
            <hr />

            <h2>A 50%-width data table</h2>
            <a id="city-list3" href="<%: Url.Action("IndexAjaxList", "Home") %>" class="sample-list"></a>

            <br style="clear: both;" />
            <hr />

            <h2>Local data sample (data loaded from javascript arrays)</h2>
            <a id="local-data-list" href="#"></a>
            <br style="clear: both;" />
            <hr />

            <h2>With bulk actions</h2>
            <a id="city-list4" href="<%: Url.Action("IndexAjaxList", "Home") %>" class="sample-list"></a>
            <br style="clear: both;" />
            <hr />
        </div>
        <div>
            <h2>Here is HomeController</h2>
            <pre>
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

            using (var context = new WorldEntities())
            {
                if (page == null)
                    page = 0;
                int pageSize = 20;
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
                var model = new TableDataPage() { current_page = page.Value, total_page = (count / pageSize + (count % pageSize > 0 ? 1 : 0)), page_size = pageSize, total = count };

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

                return Json(model, JsonRequestBehavior.AllowGet);
            }

        }
        </pre>
        </div>
    </div>
</body>
</html>
