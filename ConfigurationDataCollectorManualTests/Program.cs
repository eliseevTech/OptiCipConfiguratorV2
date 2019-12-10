using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;

namespace ConfigurationDataCollectorManualTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileFullPath = @"C:\Users\sesa507770\Desktop\SE\pepsi\Новый проект 2019\Владимир\ВладимирExchangeTable.xlsx"
            ;
            List<RequiredData> neededColums = new List<RequiredData>()
            {
                new RequiredData("Station"),
                new RequiredData("Variable ENG"),
                new RequiredData("Color",RequiredData.DataType.color)
               
            };
            Dictionary<string, List<string>> result;

            IDataCollector dataCollector = new ExcelDataCollector();

            result = dataCollector.GetData(fileFullPath, neededColums);
            for (int i = 0; i < result.First(r=>r.Value != null).Value.Count; i++)
            {
               foreach(var col in result.Values)
                {
                    if (col != null)
                    {
                    Console.Write(col[i] + " | ");
                    }                
                }
                Console.WriteLine();
            }

      

            Console.ReadLine();
        }

        static Dictionary<string, List<string>> Test2(string fileFullPath, List<RequiredData> neededColums)
        {
            IDataCollector dataCollector = new ExcelDataCollector();
            return dataCollector.GetData(fileFullPath, neededColums);
        }

        static void Test1(string fileFullPath, List<RequiredData> neededColums)
        {
            ExcelFactory excelFactory = new ExcelFactory();
            var excel = excelFactory.CreateFromFile(fileFullPath);

    
            ExcelParser excelParser = new ExcelParser(neededColums);
            var _results = excelParser.ParseFrom(excel);
            foreach (var R in _results)
            {
                if (R.Value == null)
                {
                    continue;
                }
                Console.WriteLine(R.Key);
                foreach (var V in R.Value)
                {
                    Console.WriteLine(V);
                }
            }
        }

    }
}
