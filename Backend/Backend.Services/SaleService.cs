using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Backend.Data;
using Newtonsoft.Json;

namespace Backend.Services
{
    public class SaleService : ISaleService
    {
        private readonly CSVParser _data;
        private readonly SalesTable _salesTable;

        public SaleService()
        {
            _data = new CSVParser();
            _salesTable = this.GetDataTable();
        }

        public SalesTable GetDataTable()
        {
            return _data.GetSalesTable();
        }

        public string GetSalesBetweenRange(string fromDate, string toDate)
        {
            /*  TODO
             *  Loop through all the columns of the sales table and use the names of the columsn to filter.
             */
            IEnumerable<object> filter1 = GetFilteredData(fromDate, toDate, "Teddybear");
            IEnumerable<object> filter2 = GetFilteredData(fromDate, toDate, "Chair");
            IEnumerable<object> filter3 = GetFilteredData(fromDate, toDate, "Table");
            IEnumerable<object> filter4 = GetFilteredData(fromDate, toDate, "Lamp");

            return JsonConvert.SerializeObject(filter1.Concat(filter2).Concat(filter3).Concat(filter4));
        }
        
        public IEnumerable<object> GetFilteredData(string fromDate, string toDate, string productName)
        {
            DataView dv = _salesTable.AsDataView();
            dv.Sort = "Date asc";
            dv.RowFilter = $"Date >= #{fromDate}# AND Date <= #{toDate}#";

            DataTable sortedTable = dv.ToTable();

            // Filter through the table and calculate the sum of grouped products with the same date.
            var result = from tab in sortedTable.AsEnumerable()
                         group tab by tab["Date"]
                into groupDt
                         select new
                         {
                             Product = productName,
                             Price = groupDt.Sum((r) => decimal.Parse(r["Price"].ToString())),
                             Quantity = groupDt.Sum((r) => int.Parse(r["Quantity"].ToString())),
                             Date = groupDt.Key
                         };

            return result;
        }
    }
}
