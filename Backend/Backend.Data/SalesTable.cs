using System;
using System.Data;

namespace Backend.Data
{
    public class SalesTable : DataTable
    {
        public SalesTable()
        {
            Columns.Add(new DataColumn("Product", typeof(string)));
            Columns.Add(new DataColumn("Price", typeof(double)));
            Columns.Add(new DataColumn("Quantity", typeof(int)));
            Columns.Add(new DataColumn("Date", typeof(DateTime)));
        }

        protected override Type GetRowType()
        {
            return typeof(SalesRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SalesRow(builder);
        }

        public DataRow this[int idx]
        {
            get { return (DataRow)Rows[idx]; }
        }

        public void Add(DataRow row)
        {
            Rows.Add(row);
        }

        public void Remove(DataRow row)
        {
            Rows.Remove(row);
        }

        public DataRow GetNewRow()
        {
            DataRow row = (DataRow)NewRow();
            return row;
        }
    }
}