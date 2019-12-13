using OptiCipAdministratorHelper2.View;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Services
{
    public class WindowLocator
    {
        IComponentContext _container;
        public WindowLocator(ILifetimeScope container)
        {
            _container = container;            
        }


        public void RunOpcConfigurator()
        {
            _container.Resolve<OpcConfigCreatorWindow>().Show();
        }


    }
}
