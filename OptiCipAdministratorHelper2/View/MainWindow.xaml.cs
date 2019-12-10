using OptiCipAdministratorHelper2.Services;
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

        public MainWindow(LanguageChangeServices languageChangeServices)
        {
            _languageChangeServices = languageChangeServices;
            InitializeComponent();

            //LanguageChangeServices.LanguageChanged += LanguageChanged;

            //CultureInfo currLang = LanguageChangeServices.Language;

            ////Заполняем меню смены языка:
            //menuLanguage.Items.Clear();
            //foreach (var lang in App.Languages)
            //{
            //    MenuItem menuLang = new MenuItem();
            //    menuLang.Header = lang.DisplayName;
            //    menuLang.Tag = lang;
            //    menuLang.IsChecked = lang.Equals(currLang);
            //    menuLang.Click += ChangeLanguageClick;
            //    menuLanguage.Items.Add(menuLang);
            //}


        }


        //private void LanguageChanged(Object sender, EventArgs e)
        //{
        //    CultureInfo currLang = LanguageChangeServices.Language;

        //    //Отмечаем нужный пункт смены языка как выбранный язык
        //    foreach (MenuItem i in menuLanguage.Items)
        //    {
        //        CultureInfo ci = i.Tag as CultureInfo;
        //        i.IsChecked = ci != null && ci.Equals(currLang);
        //    }
        //}

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

        public void ChangeLanguage(string lang)
        {
            string messageText = string.Format(OptiCipAdministratorHelper2.Resources.View.MainWindow.Local.ChangeLangMessage,lang) ;
            string messageHead = OptiCipAdministratorHelper2.Resources.View.MainWindow.Local.ChangeLangMessageBoxName;

            MessageBoxResult result = MessageBox.Show(messageText,
                                          messageHead,
                                          MessageBoxButton.OK);

        }
    }


}

