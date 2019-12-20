using OptiCipAdministratorHelper2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.View.OpcConfig.Model
{
    class OpcConfigModel : ModelBase
    {
  
        private string dataType;
        public string DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
                OnPropertyChanged("DataType");
            }
        }

        private string dbAddress;
        public string DbAddress
        {
            get { return dbAddress; }
            set
            {
                dbAddress = value;
                OnPropertyChanged("DbAddress");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private string tagName;
        public string TagName
        {
            get { return tagName; }
            set
            {
                tagName = value;
                OnPropertyChanged("Title");
            }
        }

        private int excelWorksheet;
        public int ExcelWorksheet
        {
            get { return excelWorksheet; }
            set { excelWorksheet = value; }
        }

        private string outputFileFullName;
        public string OutputFileFullName
        {
            get { return outputFileFullName; }
            set { outputFileFullName = value; }
        }

        private string scanRate;
        public string ScanRate
        {
            get { return scanRate; }
            set { scanRate = value; }
        }





    }
}
