using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using EntityAccessOnFramework.Models;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Services
{
    public class ExcelReader
    {
        IDataCollector _dataCollector;

        public string TagNameColumnName { get; set; }
        public string TagAliasColumnName { get; set; }
        public string TagColorColumnName { get; set; }
        public string TagTypeColumnName { get; set; }
        public string TagUnitsColumnName { get; set; }

        /// <summary>
        /// Колонка фильтрации, берем данные только где колонка соответсвтует филтру
        /// </summary>
        public string FilterNameColumnName { get; set; }
        /// <summary>
        /// Значение фильтра
        /// </summary>
        public string FilterName { get; set; }


        public int WorksheetNumber { get; set; }

        public string ExcelPath { get; set; }

        //string TagMinColumnName { get; set; }
        //string TagMaxColumnName { get; set; }



        public ExcelReader(IDataCollector dataCollector)
        {
            _dataCollector = dataCollector;
        }

        public List<LineTagFacade> GetTagsForLine(Line line, OpcShortLink opcShortLink)
        {
            var collectResult = ReadAllTagsFromExcel();
            List<LineTagFacade> lineTagFacades = new List<LineTagFacade>();


            for (int i = 0; i < collectResult.First().Value.Count(); i++)
            {
                ///если нет имени пропускаем
                if (collectResult[TagNameColumnName][i] == null)
                {
                    continue;
                }
                ///если нет имя не соответствует линии
                if (collectResult[FilterNameColumnName][i] == null || collectResult[FilterNameColumnName][i] != FilterName)
                {
                    continue;
                }

                bool IsDigital = false;
                if (collectResult[TagTypeColumnName][i].ToLower() == "boolean" || collectResult[TagTypeColumnName][i].ToLower() == "bool")
                {
                    IsDigital = true;
                }

                LineTagFacade lineTagFacade = new LineTagFacade()
                {
                    Tag = new Tag()
                    {
                        Name = collectResult[TagNameColumnName][i],
                        Alias = collectResult[TagAliasColumnName][i],           
                        Label = collectResult[TagNameColumnName][i],
                        OpcItem = collectResult[TagNameColumnName][i],
                        OpcShortLinkName = opcShortLink.Name,
                        ProjectId = line.ProjectId,
                        Type = (IsDigital) ? "TOR" : "ANA",
                        Unit = collectResult[TagUnitsColumnName][i]
                    },
                    LineTag = new LineTag()
                    {
                        ProjectId = line.ProjectId,
                        ObjectId = -1,
                        GroupId = line.GroupId,
                        LineId = line.Id,
                        StationId = line.StationId,
                        IsDigital = IsDigital  
                    },
                    HexColor = collectResult[TagColorColumnName][i]
                };
                lineTagFacades.Add(lineTagFacade);
                
            }
            return lineTagFacades;
        }





        /// <summary>
        /// Читаем все с экселя
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<string>> ReadAllTagsFromExcel()
        {
            // делаем список нужных нам данных
            List<RequiredData> requiredData = new List<RequiredData>()
                      {
                          new RequiredData(TagNameColumnName),
                          new RequiredData(TagAliasColumnName),              
                          new RequiredData(TagColorColumnName, RequiredData.DataType.color),
                          new RequiredData(TagTypeColumnName),
                          new RequiredData(TagUnitsColumnName),
                          new RequiredData(FilterNameColumnName)
                      };
            return CollectData(ExcelPath, requiredData);
        }


        private Dictionary<string, List<string>> CollectData(string FullfilePath, List<RequiredData> requiredDatas)
        {
            ///если коллекторexcel, то устанавливаем какой лист мы хотим считать
            if (_dataCollector is ExcelDataCollector)
            {
                (_dataCollector as ExcelDataCollector).WorksheetNumber = WorksheetNumber;
            }
            ///Собираем данные коллектором
            var collectResult = _dataCollector.GetData(FullfilePath, requiredDatas);

            ///проверяем все ли вхождения были найдены
            return collectResult;
        }
    }
}
