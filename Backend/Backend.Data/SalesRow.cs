using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Backend.Data
{
    class SalesRow : DataRow
    {
        public string Product
        {
            get { return (string)base["Product"]; }
            set { base["Product"] = value; }
        }
        public double Price
        {
            get { return (double)base["Price"]; }
            set { base["Price"] = value; }
        }
        public int Quantity
        {
            get { return (int)base["Quantity"]; }
            set { base["Quantity"] = value; }
        }
        public DateTime Date
        {
            get { return (DateTime)base["Date"]; }
            set { base["Date"] = value; }
        }
        internal SalesRow(DataRowBuilder builder) : base(builder)
        {
            Product = String.Empty;
            Price = 0;
            Quantity = 0;
            Date = new DateTime();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
