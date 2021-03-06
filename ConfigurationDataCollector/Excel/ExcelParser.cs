﻿using OfficeOpenXml;
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
        List<RequiredData> _requiredData;

        /// <summary>
        /// даем интересующие нас данные (заголовки колонок)
        /// </summary>
        /// <param name="variableColumns">заголовки колонок</param>
        public ExcelParser(List<RequiredData> variableColumns)
        {
            _requiredData = variableColumns;            
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
            foreach (var OneRequiredData in _requiredData)
            {
                ///ищем колонку - заголовок
                ///и ее данные
                var resultValues = GetColumnValues(worksheet, OneRequiredData);
                _results.Add(OneRequiredData.DataName, resultValues);          
            }
            return _results;
        }

        /// <summary>
        /// Ищем колонку с таким заголовком, затем берем ее данные
        /// </summary>
        /// <param name="worksheet">ссылка на имплементацию листа екселя</param>
        /// <param name="requiredData">имя колонки</param>
        /// <returns></returns>
        private List<string> GetColumnValues(ExcelWorksheet worksheet, RequiredData requiredData)
        {
            ///ищем колонку - заголовок
            var columnHeaderCell = worksheet.Cells.FirstOrDefault(C => C.GetValue<string>() == requiredData.DataName);
            if (columnHeaderCell == null)
            {
                return null;
            }
            ///кешируем номер колонки
            int columnNumber = columnHeaderCell.Start.Column;

            List<string> resultValues = new List<string>();
            for (int i = columnHeaderCell.Start.Row + 1; i < worksheet.Dimension.End.Row; i++)
            {
                if (requiredData.Type == RequiredData.DataType.value)
                {
                    var val = worksheet.Cells[i, columnNumber].Value;
                    if (val == null)
                    {
                        resultValues.Add("");
                    }
                    else
                    {
                        resultValues.Add(val.ToString());
                    }                    
                }
                else if (requiredData.Type == RequiredData.DataType.color) 
                {
                    var color = (string)worksheet.Cells[i, columnNumber].Style.Fill.BackgroundColor.Rgb;

                    var colorWithoutAlfa = ExcelParser.RemoveAlfa(color);
                    
                    resultValues.Add(colorWithoutAlfa);
                } 
                else
                {
                    throw new InvalidOperationException("No Datatype of requiredData");
                }           
            }
            return resultValues;
        }


        /// <summary>
        /// удаляем альфаканал из цвета
        /// </summary>
        /// <param name="colorWithAlfa">#AARRGGBB</param>
        /// <returns>#RRGGBB</returns>
        public static string RemoveAlfa(string colorWithAlfa)
        {
            if (string.IsNullOrEmpty(colorWithAlfa))
            {
                return "#FFFFFF";
            }
            int colorLengthWithOutAlfa = 7;
            if (colorWithAlfa.Length == colorLengthWithOutAlfa)
            {
                return colorWithAlfa; 
            }
            return "#" + colorWithAlfa.Substring(2, 6);
        }
    }
}
