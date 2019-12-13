using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDataCollector
{

    public class RequiredData
    {
        public RequiredData() { }
        public RequiredData(string dataName, DataType type = DataType.value)
        {
            DataName = dataName;
            Type = type;
        }

        public enum DataType
        {
            value, color
        }

        public string DataName { get; set; }
        
        /// <summary>
        /// Тип данных из ячейки (значение или цвет ячейки)
        /// </summary>
        public DataType Type { get; set; }
    }

}
