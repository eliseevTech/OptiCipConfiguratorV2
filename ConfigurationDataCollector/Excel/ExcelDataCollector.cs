using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDataCollector.Excel
{
    /// <summary>
    /// С екселем действует соглашение о длинне. Не плодити лишние строки, т.к. коллектор будет сканить все, до конца
    /// </summary>
    public class ExcelDataCollector : IDataCollector
    {
        /// <summary>
        /// Получаем данные из excel
        /// </summary>
        /// <param name="fileFullName">Он же dataRepository \ путь к файлу excel</param>
        /// <param name="neededData"></param>
        /// <returns></returns>
        public Dictionary<string, List<string>> GetData(string fileFullName, List<string> neededData)
        {
            using (ExcelFactory excelFactory = new ExcelFactory())
            {
                var excel = excelFactory.CreateFromFile(fileFullName);
                using (ExcelParser excelParser = new ExcelParser(neededData))
                {
                    return excelParser.ParseFrom(excel);
                }
            };
        

        }
    }
}
