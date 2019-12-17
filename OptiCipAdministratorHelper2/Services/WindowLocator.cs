using OptiCipAdministratorHelper2.View;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Services
{
    /// <summary>
    /// Класс запуска окон
    /// </summary>
    public class WindowLocator
    {
        IComponentContext _container;
        public WindowLocator(ILifetimeScope container)
        {
            _container = container;            
        }

        /// <summary>
        /// Запустить окно опс конфигурации
        /// </summary>
        public void RunOpcConfigurator()
        {
            _container.Resolve<OpcConfigCreatorWindow>().Show();
        }


    }
}
