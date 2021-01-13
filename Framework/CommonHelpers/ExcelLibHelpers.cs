using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Framework.CommonHelpers
{
    public class ExcelLibHelpers
    {
        static List<Datacollection> dataCol = new List<Datacollection>();

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        public static void ClearData()
        {
            dataCol.Clear();
        }

        private static DataTable ExcelToDataTable(string fileName, string SheetName)
        {
            //Added after installing Nuget package - System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Open file and return as Stream
            using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    //excelReader.IsFirstRowAsColumnNames = true;

                    //Return as dataset
                    DataSet result = excelReader.AsDataSet();
                    //Get all the tables
                    DataTableCollection table = result.Tables;

                    // store it in data table
                    DataTable resultTable = table[SheetName];

                    //excelReader.Dispose();
                    //excelReader.Close();
                    // return
                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                rowNumber = rowNumber - 1;
                string data = (from colData in dataCol
                                where colData.colName == columnName && colData.rowNumber == rowNumber
                                select colData.colValue).SingleOrDefault();

                return data.ToString();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                return null;
            }
        }

        public static void PopulateInCollection(string fileName, string SheetName)
        {
            ExcelLibHelpers.ClearData();
            DataTable table = ExcelToDataTable(fileName, SheetName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };

                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }
    }
}
