using EntityAccessOnFramework.Services;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.Areas.MainWindow.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main.ViewModel;

namespace OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class OptiCipConfigMain : Window
    {
        public OptiCipConfigMain(
            AccessContextService accessContextService,
            WindowLocator windowLocator
            )
        {
            DataContext = new OptiCipConfigMainViewModel(accessContextService, new ConfigurationFacade(accessContextService.Context), windowLocator);
            InitializeComponent();
        }
    }
}
