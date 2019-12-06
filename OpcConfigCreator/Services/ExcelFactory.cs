using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace OpcConfigCreator.Services.Excel
{
    public class ExcelParser
    {
        public string NameOfVariableEnColumn { get; set; } = "Variable ENG";
        public string NameOfVariableRuColumn { get; set; } = "Variable RUS";
        public string NameOfVariableRuColumn { get; set; } = "Variable RUS";

        public ICollection<OpcTag> ParseToOpcConf(ExcelPackage excel)
        {

        }
    }
}
