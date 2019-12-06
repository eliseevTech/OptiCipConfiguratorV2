using System.Collections.Generic;

namespace ConfigurationDataCollector
{
    /// <summary>
    /// Интерфейс коллектора данных из экселя или еще откудато. 
    /// </summary>
    public interface IDataCollector 
    {
        /// <summary>
        /// Получаем данные
        /// </summary>
        /// <param name="dataRepository">Репозиторий данных, например файл в случае с excelDataCollector</param>
        /// <param name="neededData">Данные которые хотим получить</param>
        /// <returns></returns>
        Dictionary<string, List<string>> GetData(string dataRepository, List<string> neededData);
    }
}