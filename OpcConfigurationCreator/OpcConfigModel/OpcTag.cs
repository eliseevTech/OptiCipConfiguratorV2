using System;
using System.Text;
using System.Threading.Tasks;

namespace OpcConfigurationCreator
{
    public class OpcTag : IOpcTag
    {
        public string TagName { get; set; }
        public string Address { get; set; }
        public string DataType { get; set; }
        public string RespectDataType { get; set; }
        public string ClientAccess { get; set; }
        public string ScanRate { get; set; }
        public string Scaling { get; set; }
        public string RawLow { get; set; }
        public string RawHigh { get; set; }
        public string ScaledLow { get; set; }
        public string ScaledHigh { get; set; }
        public string ScaledDataType { get; set; }
        public string ClampLow { get; set; }
        public string ClampHigh { get; set; }
        public string EngUnits { get; set; }
        public string Description { get; set; }
        public string NegateValue { get; set; }

        /// <summary>
        /// Возвращаем строку для опс конфигурации в формате CSV
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TagName
                .Add(Address)
                .Add(DataType)
                .Add(RespectDataType)
                .Add(ClientAccess)
                .Add(ScanRate)
                .Add(Scaling)
                .Add(RawLow)
                .Add(RawHigh)
                .Add(ScaledLow)
                .Add(ScaledHigh)
                .Add(ScaledDataType)
                .Add(ClampLow)
                .Add(ClampHigh)
                .Add(EngUnits)
                .Add(Description)
                .Add(NegateValue);
        }
    }

    static class StringExtantion
    {
        public static string Add(this string baseString, string stringToAdd)
        {
            return baseString + "," + stringToAdd;
        }
    }
}
