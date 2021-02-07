using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Newtonsoft.Json.JsonConvert;

namespace Excel
{
    public class Open
    {
        private string fileName;
        public string ExceptionMessege = "Incorrect signature of Excel data";

        public Open(string fileName,
            bool isCurrentDirectory = true) => this.fileName = isCurrentDirectory ? $"{Directory.GetCurrentDirectory()}\\" + fileName : fileName;

        public string this[int row, int column]
        {
            get
            {
                byte[] bin = File.ReadAllBytes(fileName);
                using (MemoryStream stream = new MemoryStream(bin))
                {
                    using (ExcelPackage excelPackage = new ExcelPackage(stream))
                    {
                        ExcelWorksheet obj = excelPackage.Workbook.Worksheets[0];
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        return obj.Cells[row, column].Value.ToString();
                    }
                }
            }
        }
        public T RowTo<T>(int row = 0, int colomn = 1, int WorksheetsIndex = 0)
        {
            byte[] bin = File.ReadAllBytes(fileName);
            using MemoryStream stream = new MemoryStream(bin);
            using ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet obj = excelPackage.Workbook.Worksheets[WorksheetsIndex];
            return this.Parse<T>(obj, row, colomn);
        }

        public List<T> toList<T>(int row = 1, int colomn = 1, int WorksheetsIndex = 0)
        {
            byte[] bin = File.ReadAllBytes(fileName);
            using MemoryStream stream = new MemoryStream(bin);
            using ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



            ExcelWorksheet obj = excelPackage.Workbook.Worksheets[WorksheetsIndex];
            var list = new List<T>();
            // var i = ref row;
            while (true)
            {
                try
                {
                    row++;
                    list.Add(this.Parse<T>(obj, row, colomn));
                }
                catch (System.Exception)
                {
                    break;
                }
            }
            return list;

        }

        private T Parse<T>(ExcelWorksheet reader, int row = 0, int colomn = 1)
        {
            string typeString = @"{";
            var props = typeof(T).GetProperties();
            for (int i = colomn; i < props.Count() + colomn; i++)
            {
                typeString += $" '{props[i - 1].Name}': '{reader.Cells[row, i].Value}' ,";
            }
            typeString += "}";
            return DeserializeObject<T>(typeString);
        }


    }
}
