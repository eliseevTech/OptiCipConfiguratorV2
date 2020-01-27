using ConfigurationDataCollector;
using NLog;
using OpcConfigurationCreator;
using OptiCipAdministratorHelper2.Areas.OpcConfig.ViewModel;
using System.Windows;


namespace OptiCipAdministratorHelper2.Areas.OpcConfig
{
    /// <summary>
    /// Interaction logic for OpcConfigCreatorWindow.xaml
    /// </summary>
    public partial class OpcConfigCreatorWindow : Window
    {
        public OpcConfigCreatorWindow(IDataCollector dataCollector, ConfigurationBuilder configurationBuilder, ILogger logger)
        {
            DataContext = new OpcConfigCreatorWindowViewModel(dataCollector, configurationBuilder, logger);
            InitializeComponent();
        }
    }
}
