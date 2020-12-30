using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Backend.Data
{
    class CSVParser
    {
        private string filePath = "../sales.csv";
        private SalesTable _st = null;
        public CSVParser()
        {
            readCSV();
        }
        private void readCSV()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(';');
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = this._st.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        string tempValue = rows[i].Replace("\"", "");
                        switch (i)
                        {
                            // String
                            case 0:
                                dr[i] = tempValue;
                                break;

                            // Price
                            case 1:
                                dr[i] = Double.Parse(tempValue.Replace(".", "").Replace(",", "."));
                                break;

                            // Amount
                            case 2:
                                dr[i] = int.Parse(tempValue);
                                break;

                            // Date
                            case 3:
                                dr[i] = DateTime.Parse(tempValue);
                                break;
                        }
                    }
                    
                    _st.Rows.Add(dr);
                }
            }

            Console.WriteLine("Parsed CSV");
        }
    }


}
