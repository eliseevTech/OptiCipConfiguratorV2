using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ExcelController
{
    public static class ExcelFactory
    {
        /// <summary>
        /// Подставляем 
        /// </summary>
        /// <param name="filePath">example "C:\\Users\\Scott.Atkinson\\Desktop\\Book.xls" </param>
        public static ExcelPackage CreateFromFile(string filePath)
        {
            FileInfo XlsFile = new FileInfo(filePath);
            return new ExcelPackage(XlsFile);
        }
    }
}
