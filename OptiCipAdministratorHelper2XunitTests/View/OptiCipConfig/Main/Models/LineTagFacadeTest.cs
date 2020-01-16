using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main.Models;

namespace OptiCipAdministratorHelper2XunitTests.View.OptiCipConfig.Main.Models
{

    public class LineTagFacadeTest
    {

        [Theory]
        [InlineData(16777215, "#FFFFFF")] //если меньше символов то делаем белый
        [InlineData(32768, "#008000")]
        [InlineData(255, "#FF0000")]
        [InlineData(16711680, "#0000FF")]
        public void HexColor(int input, string expectedResult)
        {
           LineTagFacade lineTagFacade = new LineTagFacade();
           var actual = lineTagFacade.ToHex(input);
           Assert.Equal(expectedResult, actual);
        }
        


        [Theory]
        [InlineData("#00", 16777215)] //если меньше символов то делаем белый
        [InlineData("#008000", 32768)]
        [InlineData("#FF0000", 255)]
        [InlineData("#0000FF", 16711680)]
        public void ToDec(string input, int expectedResult)
        {
            LineTagFacade lineTagFacade = new LineTagFacade();
            var actual = lineTagFacade.ToDec(input);
            Assert.Equal(expectedResult, actual);
        }

    }
}
