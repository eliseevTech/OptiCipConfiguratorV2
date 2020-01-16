using OptiCipAdministratorHelper2.Areas;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCipAdministratorHelper2.Areas.OpcConfig;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.AddLineTag;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.AddLineTag.ViewModel;
using EntityAccessOnFramework.Models;

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


        /// <summary>
        /// Запустить окно опс конфигурации
        /// </summary>
        public void RunOptiCipConfiguratorMain()
        {
            _container.Resolve<OptiCipConfigMain>().Show();
        }


        public void RunAddLineTagToOptiCipConfiguration(Line line)
        {
            var window = _container.Resolve<AddLineTagPage>();
            var context = _container.Resolve<AddLineTagViewModel>();
            context.SetLine(line);
            window.DataContext = context;
            window.Show();
        }
    }
}
