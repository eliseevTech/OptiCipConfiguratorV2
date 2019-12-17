using ConfigurationDataCollector;
using OpcConfigurationCreator;
using OptiCipAdministratorHelper2.ViewModel;
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

namespace OptiCipAdministratorHelper2.View
{
    /// <summary>
    /// Interaction logic for OpcConfigCreatorWindow.xaml
    /// </summary>
    public partial class OpcConfigCreatorWindow : Window
    {
        public OpcConfigCreatorWindow(IDataCollector dataCollector, ConfigurationBuilder configurationBuilder)
        {
            DataContext = new OpcConfigCreatorWindowViewModel(dataCollector, configurationBuilder);
            InitializeComponent();
        }
    }
}
