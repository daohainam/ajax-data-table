using System;
using System.Collections.Generic;
using System.Text;

namespace AjaxDataTable
{
   
    public class TableDataColumn
    {
        public enum Aligns
        {
            left, right, center
        }

        public enum DataTypes
        {
            Text, Boolean, Index, CheckBox, Action
        }    


        public string name { get; private set; }
        public string title { get; private set; }
        public string type { get; private set; }
        public string width { get; private set; }
        public string align { get; private set; }
        public bool sorting_enabled { get; private set; }
        public bool visible { get; private set; }

        public TableDataColumn(string name, string title, string width, Aligns align, bool sorting_enabled, bool visible = true, DataTypes dataType = DataTypes.Text)
        {
            string type;

            switch (dataType)
            {
                case DataTypes.Boolean:
                    type = "bool";
                    break;
                case DataTypes.Index:
                    type = "index";
                    break;
                case DataTypes.CheckBox:
                    type = "check";
                    break;
                case DataTypes.Action:
                    type = "action";
                    break;
                default:
                    type = "text";
                    break;
            }

            this.name = name;
            this.title = title;
            this.type = type;
            this.width = width;
            this.align = align.ToString();
            this.sorting_enabled = sorting_enabled;
            this.visible = visible;
        }
    }

    public class IndexTableDataColumn : TableDataColumn
    {
        public IndexTableDataColumn(string title, string width = "30px")
            : base("_index", title, width, Aligns.center, false, true, DataTypes.Index)
        {
        }
    }

    public class CheckBoxTableDataColumn : TableDataColumn
    {
        public CheckBoxTableDataColumn(string title, string width = "60px")
            : base("_check", title, width, Aligns.center, false, true, DataTypes.CheckBox)
        {
        }
    }

    public class TableDataModel
    {
        public TableDataColumn[] columns { get; set; }
    }

    public class TableDataPage
    {
        public object data { get; set; }
        public int current_page { get; set; }
        public int total_page { get; set; }
        public int page_size { get; set; }
        public int total { get; set; }
        public string sort_by { get; set; }
        public string sort_direction { get; set; }
        public object summary { get; set; }
    }
}
