using ConfigurationDataCollector.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConfigurationDataCollectorXunitTests.Excel
{
    public class ExcelParserTests
    {

        [Theory]
        [InlineData("FFRRGGBB", "#RRGGBB")]
        [InlineData("FFRRG", "#FFFFFF")]
        public void RemoveAlfaTests(string actual, string expected)
        {
            var result = ExcelParser.RemoveAlfa(actual);
            Assert.Equal(expected, result);
        }


    }
}
