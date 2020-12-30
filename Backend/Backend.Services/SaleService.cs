using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Backend.Data;

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
            return "Parsed CSV";
        }

        public string filteredData(string fromDate, string toDate, string productName)
        {
            DataView dv = _salesTable.AsDataView();
            
            
            return "";
        }
    }
}
