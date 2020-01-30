using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using EntityAccessOnFramework.Models;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Areas.OptiCipConfig.Services
{
    public class ExcelReader
    {
        IDataCollector _dataCollector;

        public string TagNameColumnName { get; set; }
        public string TagAliasColumnName { get; set; }
        public string TagLabelColumnName { get; set; }

        public string TagColorColumnName { get; set; }
        public string TagTypeColumnName { get; set; }
        public string TagUnitsColumnName { get; set; }
        public string MinValueColumnName { get; set; }
        public string MaxValueColumnName { get; set; }

        /// <summary>
        /// Колонка фильтрации, берем данные только где колонка соответсвтует филтру
        /// </summary>
        public string FilterNameColumnName { get; set; }
        /// <summary>
        /// Значение фильтра
        /// </summary>
        public string FilterValue { get; set; }


        public int WorksheetNumber { get; set; }

        public string ExcelPath { get; set; }

        //string TagMinColumnName { get; set; }
        //string TagMaxColumnName { get; set; }



        public ExcelReader(IDataCollector dataCollector)
        {
            _dataCollector = dataCollector;
        }

        public List<LineTagFacade> GetTagsForLine(Line line, string opcShortLinkName)
        {
            var collectResult = ReadAllTagsFromExcel();
            List<LineTagFacade> lineTagFacades = new List<LineTagFacade>();

            int digitalTagPosition = 0;

            for (int i = 0; i < collectResult.First().Value.Count(); i++)
            {
                ///если нет имени пропускаем
                if (collectResult[TagNameColumnName][i] == null)
                {
                    continue;
                }
                ///если нет имя не соответствует линии
                if (collectResult[FilterNameColumnName][i] == null || collectResult[FilterNameColumnName][i] != FilterValue)
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
                        Label = collectResult[TagLabelColumnName][i],
                        OpcItem = collectResult[TagNameColumnName][i],
                        OpcShortLinkName = opcShortLinkName,
                        ProjectId = line.ProjectId,
                        Type = (IsDigital) ? "TOR" : "ANA",                       
                        Unit = collectResult[TagUnitsColumnName][i],
                        CODE_TRAITEMENT = 0,
                        PRECIS = 0
                    },
                    LineTag = new LineTag()
                    {
                        ProjectId = line.ProjectId,
                        ObjectId = -1,
                        GroupId = line.GroupId,
                        LineId = line.Id,
                        StationId = line.StationId,
                        IsDigital = IsDigital,
                        DIG_TITRE = (IsDigital) ? "Tab Base" : "",
                        DIG_REFSTYLE = 1,
                        DIG_HEIGHT = (IsDigital) ? 1 : 0,
                        PositionLow = (IsDigital) ? digitalTagPosition++ : 0,
                        PositionHigh = (IsDigital) ? digitalTagPosition++ : 0,
                        Width = 1
                    },
                    HexColor = collectResult[TagColorColumnName][i]
                };


                SetMinMax(collectResult[MinValueColumnName][i], collectResult[MaxValueColumnName][i], lineTagFacade);

                lineTagFacades.Add(lineTagFacade);

            }
            return lineTagFacades;
        }

        private void SetMinMax(string minString, string maxString, LineTagFacade lineTagFacade)
        {
            int min = 0;
            int.TryParse(minString, out min);

            lineTagFacade.Tag.PhysicalMin = min;
            lineTagFacade.Tag.MapMin = min;

            int max = 0;
            int.TryParse(maxString, out max);
            lineTagFacade.Tag.PhysicalMax = max;
            lineTagFacade.Tag.MapMax = max;
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
                          new RequiredData(TagLabelColumnName),
                          new RequiredData(TagColorColumnName, RequiredData.DataType.color),
                          new RequiredData(TagTypeColumnName),
                          new RequiredData(TagUnitsColumnName),
                          new RequiredData(FilterNameColumnName),
                          new RequiredData(MinValueColumnName),
                          new RequiredData(MaxValueColumnName),
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
