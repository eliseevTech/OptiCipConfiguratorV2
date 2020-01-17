using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCipAdministratorHelper2.Services;
using Xunit;


namespace OptiCipAdministratorHelper2XunitTests.Service
{
    public class WindowsServiceTests
    {
  
        [Theory]
        //[InlineData(true, "Administrators")] // works on EN windows version
        [InlineData(false, "dasd23pp312-23-1231-2d12d-12de12d12-d12s-12s")]
        public void CheckUsersGroupTests(bool expected, string actual)
        {
            WindowsService winowsService = new WindowsService();
            var result = winowsService.CheckOneGroup(actual);
            Assert.Equal(expected, result);
        }
    }
}
