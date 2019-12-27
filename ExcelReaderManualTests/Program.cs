using ConfigurationDataCollector.Excel;
using EntityAccessOnFramework.Models;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReaderManualTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Создаем чтателя excel
            ExcelReader excelReader = new ExcelReader(new ExcelDataCollector());
            //задаем путь
            excelReader.ExcelPath = @"C:\Users\sesa507770\Desktop\SE\pepsi\Новый проект 2019\Владимир\ВладимирExchangeTableV2.xlsx";
            //номер листа
            excelReader.WorksheetNumber = 2;
            //проходим по всем колонкам
            excelReader.TagAliasColumnName = "Variable RUS";
            excelReader.TagColorColumnName = "Color";
            excelReader.TagNameColumnName = "Variable ENG";
            excelReader.FilterNameColumnName = "FilterName";
            excelReader.TagTypeColumnName = "Type";
            excelReader.TagUnitsColumnName = "Units";

            excelReader.FilterName = "CIP1_1";
            Line line = new Line()
            {
                Id = 3,
                StationId = 2,
                GroupId = 1,
                Name = "Line"
            };
            OpcShortLink opcShortLink = new OpcShortLink()
            {
                Name = "opcShortLinkName"
            };

            var result = excelReader.GetTagsForLine(line, opcShortLink);
            Console.WriteLine("dsa");
        }
    }
}
