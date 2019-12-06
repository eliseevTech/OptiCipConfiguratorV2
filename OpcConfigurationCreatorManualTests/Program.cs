using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcConfigurationCreator;

namespace OpcConfigurationCreatorManualTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IOpcTag> opcTags = new List<IOpcTag>()
            {
                new OpcTag()
                {
                    Address = "dsadsa"
                }
            };
            ConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder(opcTags);
            ConfigurationBuilder.BuildToFile();

        }
    }
}
