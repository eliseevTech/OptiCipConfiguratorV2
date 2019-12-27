using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipGetTagsFromExcel
{
    public class Reader
    {
        IDataCollector _dataCollector;

        public string TagColumnName { get; set; }
        public string TagAliasColumnName { get; set; }
        public string TagColorColumnName { get; set; }
        public string TagLineColumnName { get; set; }


        
        public int WorksheetNumber { get; set; }

        public string ExcelPath { get; set; }

        //string TagMinColumnName { get; set; }
        //string TagMaxColumnName { get; set; }
   


        public Reader(IDataCollector dataCollector)
        {
            _dataCollector = dataCollector;
        }

        public void GetTags()
        {
            var collectResult = ReadAllTagsFromExcel();
            List<LineTagFacade> lineTagFacades = new List<LineTagFacade>();


            for(int i = 0; i < collectResult.First().Value.Count(); i++)
            {
                ///если нет имени пропускаем
                if (collectResult[TagColumnName][i] == null)
                {
                    continue;
                }
                LineTagFacade lineTagFacade = new LineTagFacade()
                {
                    Tag = new Tag()
                    {
                        Name = collectResult[TagColumnName][i],
                        
                    },
                    LineTag = new LineTag()
                    {
                        Color = collectResult[TagColorColumnName][i]
                    }
                };
                lineTagFacades.Add(lineTagFacade);

            }



        
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
                          new RequiredData(TagColumnName),
                          new RequiredData(TagAliasColumnName),
                          new RequiredData(TagColorColumnName),
                          new RequiredData(TagLineColumnName, RequiredData.DataType.color)
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

    class LineTagFacade
    {
        public Tag Tag { get; set; }
        public LineTag LineTag { get; set; }
    }
}
