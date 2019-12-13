
using ConfigurationDataCollector;
using Microsoft.Win32;
using OptiCipAdministratorHelper2.Models;
using OptiCipAdministratorHelper2.Models.OpcConfiguration;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OptiCipAdministratorHelper2.ViewModel
{
    class OpcConfigCreatorWindowViewModel : ViewModelBase
    {

        IDataCollector _dataCollector { get; set; }
        public OpcConfigCreatorWindowViewModel(IDataCollector dataCollector)
        {
            _dataCollector = dataCollector;
        }

        public OpcConfigModel configModel { get; set; } = new OpcConfigModel()
        {
            TagName = "Variable ENG",
            DataType = "Type",
            DbAddress = "Full DB adr (formula)",
            Description = "Variable RUS"     
        };


        // команда добавления нового объекта
        private RelayCommand selectFile;
        public RelayCommand SelectFile
        {
            get
            {
                return selectFile ??
                  (selectFile = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter ="Excel Files (*.xlsx)|*.xlsx| All files (*.*)|*.*";
                      if (openFileDialog.ShowDialog() == true)
                          configModel.FilePath = openFileDialog.FileName;
                  }));
            }
        }


        // команда добавления нового объекта
        private RelayCommand generateOpcConfig;
        public RelayCommand GenerateOpcConfig
        {
            get
            {
                return generateOpcConfig ??
                  (generateOpcConfig = new RelayCommand(obj =>
                 {

                      // делаем список нужных нам данных
                      List<RequiredData> requiredData = new List<RequiredData>()
                      {
                          new RequiredData(configModel.TagName),
                          new RequiredData(configModel.DbAddress),
                          new RequiredData(configModel.DataType),
                          new RequiredData(configModel.Description)
                      };
                     Dictionary<string, List<string>> collectResult = CollectData(configModel.FilePath, requiredData);

                     MessageBoxResult result = MessageBox.Show(collectResult[configModel.TagName].Count().ToString(),
                                         "Confirmation",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
                     if (result == MessageBoxResult.Yes)
                     {
                         Application.Current.Shutdown();
                     }
                 }));
        }
        }


        private Dictionary<string, List<string>> CollectData(string FullfilePath, List<RequiredData> requiredDatas)
        {
            return _dataCollector.GetData(FullfilePath, requiredDatas);
        }

    }
}
