using OptiCipAdministratorHelper2.Services;

using System;

using System.Windows;
using System.Windows.Controls;

using OptiCipAdministratorHelper2.Areas.MainWindow.Resources;
using Microsoft.Win32;
using OptiCipAdministratorHelper2.Areas.MainWindow.ViewModel;
using NLog;
using System.Reflection;

namespace OptiCipAdministratorHelper2.Areas.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LanguageChangeServices _languageChangeServices;
        WindowLocator _windowLocator;
        AccessContextService _accessContextService;
        WindowsService _windowsService;
        ILogger _logger;

        public bool IsOpticipGroupOnWindows { get; set; }

        public MainWindow(
            WindowLocator windowLocator,
            LanguageChangeServices languageChangeServices,
            AccessContextService accessContextService,
            WindowsService windowsService,
             ILogger logger
            )
        {
            _languageChangeServices = languageChangeServices;
            _windowLocator = windowLocator;

            _accessContextService = accessContextService;
            _windowsService = windowsService;

            _logger = logger;

            DataContext = new MainWindowViewModel();
            InitializeComponent();

            IsOpticipGroupOnWindows = windowsService.CheckOpticipUsersGroup();
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
            string messageText = string.Format(Local.ChangeLangMessage, lang);
            string messageHead = Local.ChangeLangMessageBoxName;
            MessageBoxResult result = MessageBox.Show(messageText,
                                          messageHead,
                                          MessageBoxButton.OK);
        }

        private void OpenOpcCreatorClick(Object sender, EventArgs e)
        {
            _windowLocator.RunOpcConfigurator();
        }


        private void OpenConfiguration(Object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Opticip config file (*.mdb)|*.mdb| All files (*.*)|3*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _accessContextService.SetContext(openFileDialog.FileName);
                _windowLocator.RunOptiCipConfiguratorMain();
            }
        }


        private void GetInfoOfOpticipUserGroups(object sender, RoutedEventArgs e)
        {
            string message;
            if (!_windowsService.CheckOpticipUsersGroup())
            {
                message = Local.UserGroupInfo + "\n" + Local.UserGroupGroupIsNotOk + "\n" + Local.UserGroupAddUserLabel;
                if (MessageBox.Show(message, Local.UserGroupAddUserLabel, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _logger.Info("Try to adding windows groups", this.Name);
                    if (_windowsService.AddOptiCipGroups())
                    {
                        MessageBox.Show(Local.UserGroupAddingSuccess, Local.UserGroupAddingSuccess);
                        _logger.Info(this.Name + " adding success");
                    }
                    else
                    {
                        MessageBox.Show(Local.UserGroupAddingNotSuccess, Local.UserGroupAddingSuccess);
                        _logger.Info(this.Name + " adding failed");
                    }
                }
                return;
            }
            else
            {
                message = Local.UserGroupInfo + "\n" + Local.UserGroupGroupIsOk;
                MessageBox.Show(message, message);
            }
        }

        private void ShowInfoClick(object sender, RoutedEventArgs e)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();           
                MessageBox.Show($"Version {version}");
        }

    }
}

