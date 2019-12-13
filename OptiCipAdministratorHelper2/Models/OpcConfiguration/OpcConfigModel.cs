using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Models.OpcConfiguration
{
    class OpcConfigModel : ModelBase
    {
        private string tagName;
        private string dataType;
        private string dbAddress;
        private string description;
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

        public string TagName
        {
            get { return tagName; }
            set
            {
                tagName = value;
                OnPropertyChanged("Title");
            }
        }

        public string DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
                OnPropertyChanged("DataType");
            }
        }

        public string DbAddress
        {
            get { return dbAddress; }
            set
            {
                dbAddress = value;
                OnPropertyChanged("DbAddress");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

    }
}
