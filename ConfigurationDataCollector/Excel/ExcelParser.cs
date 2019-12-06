using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDataCollector.Excel
{
    public class ExcelParser : IDisposable
    {
        List<string> _variableColumns;

        /// <summary>
        /// даем интересующие нас данные (заголовки колонок)
        /// </summary>
        /// <param name="variableColumns">заголовки колонок</param>
        public ExcelParser(List<string> variableColumns)
        {
            _variableColumns = variableColumns;            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public Dictionary<string, List<string>> ParseFrom(ExcelPackage excel, int worksheetNumber = 1)
        {
            /// <summary>
            /// Дикшинари для результата, ключом является имя колонки, а в листе
            /// </summary>
            Dictionary<string, List<string>> _results = new Dictionary<string, List<string>>();

            ///кешируем воркшит
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[worksheetNumber];
     
            ///проходим по всем запрашиваемым колонкам
            foreach (var columnName in _variableColumns)
            {
                ///ищем колонку - заголовок
                ///и ее данные
                var resultValues = GetColumnValues(worksheet, columnName);
                _results.Add(columnName, resultValues);          
            }
            return _results;
        }
        
        /// <summary>
        /// Ищем колонку с таким заголовком, затем берем ее данные
        /// </summary>
        /// <param name="worksheet">ссылка на имплементацию листа екселя</param>
        /// <param name="columnName">имя колонки</param>
        /// <returns></returns>
        private List<string> GetColumnValues(ExcelWorksheet worksheet, string columnName)
        {
            ///ищем колонку - заголовок
            var columnHeaderCell = worksheet.Cells.FirstOrDefault(C => C.GetValue<string>() == columnName);
            if (columnHeaderCell == null)
            {
                return null;
            }
            ///кешируем номер колонки
            int columnNumber = columnHeaderCell.Start.Column;

            List<string> resultValues = new List<string>();
            for (int i = columnHeaderCell.Start.Row + 1; i < worksheet.Dimension.End.Row; i++)
            {
                resultValues.Add((string)worksheet.Cells[i, columnNumber].Value);
            }
            return resultValues;
        }

    }

 
}
