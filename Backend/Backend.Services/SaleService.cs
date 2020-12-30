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
            string filter1 = filteredData(fromDate, toDate, "Teddybear");

            // This introduced unneccesary \ characters
            //string jsonObj = JsonConvert.SerializeObject(filter1);

            return filter1;
        }
        

        // TODO Make it return a generic (?) instead of a string
        public string filteredData(string fromDate, string toDate, string productName)
        {
            DataView dv = _salesTable.AsDataView();
            dv.Sort = "Date asc";
            //dv.RowFilter = $"Date >= #{fromDate}# AND Date <= #{toDate}# AND Product = '{productName}'";

            DataTable sortedTable = dv.ToTable();

            // Filter through the table and calculate the sum of grouped products with the same date.
            var result= from tab in sortedTable.AsEnumerable()
                              group tab by tab["Date"]
                into groupDt
                              select new
                              {
                                  Product = productName,
                                  Price = groupDt.Sum((r) => decimal.Parse(r["Price"].ToString())),
                                  Quantity = groupDt.Sum((r) => int.Parse(r["Quantity"].ToString())),
                                  Date = groupDt.Key
                              };

            var resultTable = from tab in sortedTable.AsEnumerable()
                              group tab by tab["Date"]
                into groupDt
                              select new
                              {
                                  Product = "Table",
                                  Price = groupDt.Sum((r) => decimal.Parse(r["Price"].ToString())),
                                  Quantity = groupDt.Sum((r) => int.Parse(r["Quantity"].ToString())),
                                  Date = groupDt.Key
                              };

            var resultLamp = from tab in sortedTable.AsEnumerable()
                             group tab by tab["Date"]
                into groupDt
                             select new
                             {
                                 Product = "Lamp",
                                 Price = groupDt.Sum((r) => decimal.Parse(r["Price"].ToString())),
                                 Quantity = groupDt.Sum((r) => int.Parse(r["Quantity"].ToString())),
                                 Date = groupDt.Key
                             };

            var resultChair = from tab in sortedTable.AsEnumerable()
                              group tab by tab["Date"]
                into groupDt
                              select new
                              {
                                  Product = "Chair",
                                  Price = groupDt.Sum((r) => decimal.Parse(r["Price"].ToString())),
                                  Quantity = groupDt.Sum((r) => int.Parse(r["Quantity"].ToString())),
                                  Date = groupDt.Key
                              };

            // Return a JSON object based on the different results.
            return JsonConvert.SerializeObject(result.Concat(resultTable).Concat(resultLamp).Concat(resultChair));
        }
    }
}
