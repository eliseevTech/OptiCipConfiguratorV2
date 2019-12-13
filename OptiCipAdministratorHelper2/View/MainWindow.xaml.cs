using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.ViewModel;
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

namespace OptiCipAdministratorHelper2.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LanguageChangeServices _languageChangeServices;
        WindowLocator _windowService;

        public MainWindow(WindowLocator windowService,LanguageChangeServices languageChangeServices)
        {
            _languageChangeServices = languageChangeServices;
            _windowService = windowService;
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }



        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                string lang = mi.Tag as string;
                if (lang != null)
                {
                    _languageChangeServices.SetLang(lang);
                    ChangeLanguage(lang);
                }
            }
        }

        private void ChangeLanguage(string lang)
        {
            string messageText = string.Format(OptiCipAdministratorHelper2.Resources.View.MainWindow.Local.ChangeLangMessage,lang) ;
            string messageHead = OptiCipAdministratorHelper2.Resources.View.MainWindow.Local.ChangeLangMessageBoxName;
            MessageBoxResult result = MessageBox.Show(messageText,
                                          messageHead,
                                          MessageBoxButton.OK);
        }
        
        private void OpenOpcCreatorClick(Object sender, EventArgs e)
        {
            _windowService.RunOpcConfigurator(); 
        }
    }


}

