
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using Microsoft.Win32;
using OpcConfigurationCreator;
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
        IDataCollector _dataCollector;
        ConfigurationBuilder _configurationBuilder;

        public OpcConfigCreatorWindowViewModel(IDataCollector dataCollector, ConfigurationBuilder configurationBuilder)
        {
            _dataCollector = dataCollector;
            _configurationBuilder = configurationBuilder;
        }

        public OpcConfigModel configModel { get; set; } = new OpcConfigModel()
        {
            TagName = "Variable ENG",
            DataType = "Type",
            DbAddress = "Full DB adr (formula)",
            Description = "Variable RUS",
            ScanRate = "500",
            ExcelWorksheet = 1
            
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
                      openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx| All files (*.*)|*.*";
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

                      Dictionary<string, List<string>> collectResult;
                      try
                      {
                          collectResult = CollectData(configModel.FilePath, requiredData);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.StackTrace, e.Message);
                          return;
                      }

   
                      List<IOpcTag> opcTags;

                      try
                      {
                          opcTags = ToOpcTags(collectResult, configModel);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.StackTrace, e.Message);
                          return;
                      }
  
                      _configurationBuilder.AddTags(opcTags);


                      SaveFileDialog saveFileDialog = new SaveFileDialog();
                      saveFileDialog.Filter = "CSV Files (*.csv)|*.csv| All files (*.*)|*.*";
                      if (saveFileDialog.ShowDialog() == true)
                      {
                          configModel.OutputFileFullName = saveFileDialog.FileName;
                      }

                      _configurationBuilder.BuildToFile(configModel.OutputFileFullName);

                      //MessageBoxResult result = MessageBox.Show(collectResult[configModel.TagName].Count().ToString(),
                      //                    "Confirmation",
                      //                    MessageBoxButton.YesNo,
                      //                    MessageBoxImage.Question);
                      //if (result == MessageBoxResult.Yes)
                      //{
                      //    Application.Current.Shutdown();
                      //}
                  }));
            }
        }


        private Dictionary<string, List<string>> CollectData(string FullfilePath, List<RequiredData> requiredDatas)
        {
            ///если коллекторexcel, то устанавливаем какой лист мы хотим считать
            if (_dataCollector is ExcelDataCollector)
            {
                (_dataCollector as ExcelDataCollector).WorksheetNumber = configModel.ExcelWorksheet;
            }
            ///Собираем данные коллектором
            var collectResult = _dataCollector.GetData(FullfilePath, requiredDatas);

            ///проверяем все ли вхождения были найдены
            return collectResult;
        }

        private List<IOpcTag> ToOpcTags(Dictionary<string, List<string>> collectResult, OpcConfigModel configModel)
        {
            List<IOpcTag> opcTags = new List<IOpcTag>();            
            
            for(int i = 0; i < collectResult.First().Value.Count(); i++)
            {
                if (collectResult[configModel.TagName][i] == null)
                {
                    continue;
                }
                opcTags.Add(new OpcTag()
                {
                    TagName = collectResult[configModel.TagName][i].Replace(" ", String.Empty),
                    Address = collectResult[configModel.DbAddress][i],
                    Description = collectResult[configModel.Description][i],
                    DataType = collectResult[configModel.DataType][i],
                    ScanRate = configModel.ScanRate,
                    RespectDataType = "1",
                    ClientAccess = "R/W"

                }) ;
            }
            return opcTags;
        }
    }
}
