using OptiCipAdministratorHelper2.View;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiCipAdministratorHelper2.View.OpcConfig;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main;
using OptiCipAdministratorHelper2.View.OptiCipConfig.AddLineTag;
using OptiCipAdministratorHelper2.View.OptiCipConfig.AddLineTag.ViewModel;
using EntityAccessOnFramework.Models;

namespace OptiCipAdministratorHelper2.Services
{
    /// <summary>
    /// Класс запуска окон
    /// </summary>
    public class UIMessageService
    {
        IComponentContext _container;
        public UIMessageService(ILifetimeScope container)
        {
            _container = container;            
        }

    }
}
