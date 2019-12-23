using Autofac;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.View;
using System.Windows;
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using System.Collections.Generic;
using OptiCipAdministratorHelper2.View.OpcConfig;
using OptiCipAdministratorHelper2.View.MainWindow;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main;
using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Services;

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
            containerBuilder.RegisterType<OptiCipConfigMain>().AsSelf();

            containerBuilder.Register(O=> new OpcConfigurationCreator.ConfigurationBuilder(new List<OpcConfigurationCreator.IOpcTag>())).AsSelf();

            //контекст

            containerBuilder.RegisterType<AccessContextService>().AsSelf().SingleInstance();

            // работа с контекстом
            containerBuilder.RegisterType<ExcelDataCollector>().As<IDataCollector>();


            container = containerBuilder.Build();
            container.Resolve<LanguageChangeServices>().SetStartlang();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }   
    }
}
