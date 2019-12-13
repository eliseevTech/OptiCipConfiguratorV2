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
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;

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
            containerBuilder.RegisterType<MainWindow>().AsSelf();
            containerBuilder.RegisterType<WindowLocator>().AsSelf();
            containerBuilder.RegisterType<OpcConfigCreatorWindow>().AsSelf();
            containerBuilder.RegisterType<ExcelDataCollector>().As<IDataCollector>();

            container = containerBuilder.Build();
            container.Resolve<LanguageChangeServices>().SetStartlang();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }   
    }
}
