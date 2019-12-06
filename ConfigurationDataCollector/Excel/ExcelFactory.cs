using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDataCollector.Excel
{
    public class ExcelFactory : IDisposable
    {
        /// <summary>
        /// Получаем эксель из файла
        /// </summary>
        /// <param name="filePath">example "C:\\Users\\Scott.Atkinson\\Desktop\\Book.xls" </param>
        public ExcelPackage CreateFromFile(string filePath)
        {
            FileInfo XlsFile = new FileInfo(filePath);
            return new ExcelPackage(XlsFile);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
