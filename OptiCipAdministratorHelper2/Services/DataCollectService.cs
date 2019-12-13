using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OptiCipAdministratorHelper2.Services
{
    public class LanguageChangeServices
    {
        /// <summary>
        /// имя переменной в сеттинге 
        /// </summary>
        string _settingDefaultLangName;

        public LanguageChangeServices(string settingDefaultLangName = "DefaultLanguage")
        {
            _settingDefaultLangName = settingDefaultLangName;
        }

        public void SetLang(string lang)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Properties.Settings.Default[_settingDefaultLangName] = lang;
            Properties.Settings.Default.Save();
        }


        public void SetStartlang()
        {
            var lang = OptiCipAdministratorHelper2.Properties.Settings.Default[_settingDefaultLangName] as string;

            if (!new string[] { "ru", "en" }.Contains(lang))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                OptiCipAdministratorHelper2.Properties.Settings.Default[_settingDefaultLangName] = new CultureInfo("en");
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang); ;                              
        }




    }
}
