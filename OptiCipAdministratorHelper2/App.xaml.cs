using OptiCipAdministratorHelper2.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OptiCipAdministratorHelper2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static List<CultureInfo> m_Languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages
        {
            get
            {
                return m_Languages;
            }
        }

        public App()
        {
            InitializeComponent();
            LanguageChangeServices.LanguageChanged += App_LanguageChanged;

            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en")); //Нейтральная культура для этого проекта
            m_Languages.Add(new CultureInfo("ru"));

            LanguageChangeServices.Language = OptiCipAdministratorHelper2.Properties.Settings.Default.DefaultLanguage;
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            LanguageChangeServices.Language = OptiCipAdministratorHelper2.Properties.Settings.Default.DefaultLanguage;
        }

        private void App_LanguageChanged(Object sender, EventArgs e)
        {
            OptiCipAdministratorHelper2.Properties.Settings.Default.DefaultLanguage = LanguageChangeServices.Language;
            OptiCipAdministratorHelper2.Properties.Settings.Default.Save();
        }


    }
}
