using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcConfigurationCreator
{
    public class ConfigurationBuilder
    {
        private MemoryStream memoryStream;  
        
        public List<IOpcTag> OpcTags;

        public string OutFilePath { get; set; } = AppContext.BaseDirectory;

        /// <summary>
        /// Опс теги
        /// </summary>
        /// <param name="opcTags">теги опс</param>
        /// <param name="path">если путь не задан, то будет поставлен путь приложения (AppContext.BaseDirectory)</param>
        public ConfigurationBuilder(List<IOpcTag> opcTags, string path = null)
        {
            if (path != null)
            {
                OutFilePath = path;
            }
            
            OpcTags = opcTags;
        }

        /// <param name="opcTags"></param>
        /// <returns></returns>
        public ConfigurationBuilder AddTags(List<IOpcTag> opcTags)
        {
            OpcTags.AddRange(opcTags);
            return this;
        }
        
        public void BuildToFile(string fileName = "OpcConf")
        {
            fileName = $"{AppContext.BaseDirectory}/{fileName}.csv";
            StreamWriter writer = CreateFile(fileName);    
            WriteLine(writer, "Tag Name,Address,Data Type,Respect Data Type,Client Access,Scan Rate,Scaling,Raw Low,Raw High,Scaled Low,Scaled High,Scaled Data Type,Clamp Low,Clamp High,Eng Units,Description,Negate Value");
            
            foreach(var T in OpcTags)
            {
                WriteTag(writer, T);
            }
            writer.Close();
        }

        private StreamWriter CreateFile(string fileFullName)
        {
            FileInfo fileInfo = new FileInfo(fileFullName);
            FileStream stream;
            if (!fileInfo.Exists)
            {
                stream = fileInfo.Create();
            }
            else
            {
                stream = new FileStream(fileFullName, FileMode.Create);
            }
            return new StreamWriter(stream);
        }

        private void WriteTag(StreamWriter stream, IOpcTag tag)
        {
            WriteLine(stream, tag.ToString());
        }

        private void WriteLine(StreamWriter stream, string _string)
        {
            stream.WriteLine(_string);
        }
    }
}
