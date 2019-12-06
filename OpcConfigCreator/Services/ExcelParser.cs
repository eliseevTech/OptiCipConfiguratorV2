using OfficeOpenXml;
using OpcConfigCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
