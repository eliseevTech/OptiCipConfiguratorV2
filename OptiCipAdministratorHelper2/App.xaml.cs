using Autofac;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace OptiCipAdministratorHelper2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        IContainer container;

        public App()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(L => new LanguageChangeServices()).AsSelf().SingleInstance();
            container = containerBuilder.Build();
            container.Resolve<LanguageChangeServices>().SetStartlang();

            MainWindow mainWindow = new MainWindow(container.Resolve<LanguageChangeServices>());
            mainWindow.Show();
        }   
    }
}
