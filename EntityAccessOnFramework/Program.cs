using EntityAccessOnFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllStations();
            PrintAlGroups();

            using (Context C = new Context())
            {
                var s = C.Lines.ToList();
                
                foreach(var l in s)
                {
                    Console.WriteLine(l.Name);
                }
            
            }

                Console.ReadLine();
        }



        static void PrintAllStations()
        {
            using (Context C = new Context())
            {
                //JetEntityFrameworkProvider.JetConnection.ShowSqlStatements = true;

                foreach (var s in C.Stations.ToList())
                {
                    Console.WriteLine("======");
                    Console.WriteLine(s.Id);
                    Console.WriteLine(s.ProjectId);
                    Console.WriteLine(s.GroupId);
                    Console.WriteLine(s.Name);
                    Console.WriteLine(s.Type);
                }
            }
        }
        static void PrintAlGroups()
        {
            using (Context C = new Context())
            {
                //JetEntityFrameworkProvider.JetConnection.ShowSqlStatements = true;

                foreach (var s in C.Groups.ToList())
                {
                    Console.WriteLine("======");
                    Console.WriteLine(s.Id);
                    Console.WriteLine(s.ProjectId);
  
                    Console.WriteLine(s.Name);
      
                }
            }
        }
    }
}
