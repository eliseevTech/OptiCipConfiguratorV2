using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
