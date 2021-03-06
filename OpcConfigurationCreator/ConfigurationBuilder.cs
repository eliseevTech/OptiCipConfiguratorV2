﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcConfigurationCreator
{
    public class ConfigurationBuilder
    {
        public List<IOpcTag> OpcTags;

        public string _outFileFullName { get; set; } = AppContext.BaseDirectory + "/OutPutFile.csv";

        /// <summary>
        /// Опс теги
        /// </summary>
        /// <param name="opcTags">теги опс</param>
        /// <param name="path">если путь не задан, то будет поставлен путь приложения (AppContext.BaseDirectory)</param>
        public ConfigurationBuilder(List<IOpcTag> opcTags)
        {    
            OpcTags = opcTags;
        }

        public void Clear()
        {
            OpcTags.Clear();
        }

        /// <param name="opcTags"></param>
        /// <returns></returns>
        public ConfigurationBuilder AddTags(List<IOpcTag> opcTags)
        {
            OpcTags.AddRange(opcTags);
            return this;
        }
        
        public void BuildToFile(string outFileFullName = null)
        {
            if (outFileFullName != null)
            {
                _outFileFullName = outFileFullName;
            }
    
            StreamWriter writer = CreateFile(_outFileFullName);    
            WriteLineToFile(writer, "Tag Name,Address,Data Type,Respect Data Type,Client Access,Scan Rate,Scaling,Raw Low,Raw High,Scaled Low,Scaled High,Scaled Data Type,Clamp Low,Clamp High,Eng Units,Description,Negate Value");
            
            foreach(var T in OpcTags)
            {
                AddTagToFile(writer, T);
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

        private void AddTagToFile(StreamWriter stream, IOpcTag tag)
        {
            WriteLineToFile(stream, tag.ToString());
        }

        private void WriteLineToFile(StreamWriter stream, string _string)
        {
            stream.WriteLine(_string);
        }

    }
}
