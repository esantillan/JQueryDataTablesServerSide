using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class QueryBuilder
    {
        public Dictionary<String, String> SPParams { get; }
        public JQueryDataTablesRequest DataTablesrequest { get; set; }

        public QueryBuilder()
        {

        }

        public QueryBuilder(JQueryDataTablesRequest DataTablesRequest):this()
        {
            this.DataTablesrequest = DataTablesrequest;
            LoadSPParams();
        }

        public void LoadSPParams()
        {
            LoadColumnsFilters();
            LoadColumnsToOrder();
            LoadAdditionalFilters();
        }

        protected void LoadColumnsFilters()
        {
            foreach (Column column in DataTablesrequest.Columns)
            {
                if (column.Search.Value != null && column.Search.Value != String.Empty)
                {
                    SPParams.Add(column.Name, column.Search.Value);
                }
            }
        }

        protected void LoadColumnsToOrder()
        {
            byte count = 0;
            String OrderBy = "";
            foreach (ColumnOrder columnToOrder in DataTablesrequest.Order)
            {
                OrderBy += (count > 0 ? ", " : "") + DataTablesrequest.Columns[columnToOrder.Column].Name + " " + columnToOrder.Dir;
                count++;
            }
            SPParams.Add("OrderBy", OrderBy);
        }

        protected void LoadAdditionalFilters()
        {
            foreach (String key in DataTablesrequest.AdditionalFilters.Keys)
            {
                SPParams.Add(key, DataTablesrequest.AdditionalFilters[key]);
            }
        }
        
    }
}
