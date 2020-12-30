using System;

namespace Backend.Services
{
    public interface ISaleService
    {

        public string GetSalesBetweenRange(string fromDate, string toDate);
    }
}
