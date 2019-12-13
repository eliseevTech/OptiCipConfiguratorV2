using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;

namespace OptiCipAdministratorHelper2.Services
{


    public class DataCollectService<T> where T : IDataCollector
    {
        public IDataCollector CreateDataCollector()
        {
            return Activator.CreateInstance(typeof(T)) as IDataCollector;
        }
    }

  

}
