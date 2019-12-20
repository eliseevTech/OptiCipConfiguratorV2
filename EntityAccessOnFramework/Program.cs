//using EntityAccessOnFramework.Data;
//using EntityAccessOnFramework.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EntityAccessOnFramework
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //base(new JetConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Test-Project.sep'; providerName=JetEntityFrameworkProvider; Password=SEEME;"), true)
//            AccessContext _context = new AccessContext(@"C:/PRJ/c#/OptiCipAdministratorHelper/Config_test.mdb");
//            TagManager configController = new TagManager(_context);

//            configController.AddLine("newLine", _context.Stations.First());

//            PrintAllStations(_context);
//            //Console.WriteLine("-----------------");

//            //configController.AddStation("new", _context.Groups.First());

//            //PrintAllStations(_context);


//          //  PrintAllGroups(_context);

//            //using (Context C = new Context())
//            //{
//            //    var s = C.Lines.ToList();
                
//            //    foreach(var l in s)
//            //    {
//            //        Console.WriteLine(l.Name);
//            //    }
            
//            //}

//            //using (Context C = new Context())
//            //{
//            //    var s = C.Objects.ToList();

//            //    foreach (var l in s)
//            //    {
//            //        Console.WriteLine(l.Name);
//            //    }

//            //}


//            //using (Context C = new Context())
//            //{
//            //    var s = C.LineTags.ToList();

//            //    foreach (var l in s)
//            //    {
//            //        Console.WriteLine(l.Id);
//            //    }

//            //}


//            //using (Context C = new Context())
//            //{
//            //    var s = C.Tags.ToList();

//            //    foreach (var l in s)
//            //    {
//            //        Console.WriteLine(l.Name);
//            //    }

//            //}

//            Console.ReadLine();
//        }



//        static void PrintAllStations(AccessContext context)
//        {
      
//                //JetEntityFrameworkProvider.JetConnection.ShowSqlStatements = true;

//                foreach (var s in context.Stations.ToList())
//                {
//                    Console.WriteLine("======");
//                    Console.WriteLine(s.Id);
//                    Console.WriteLine(s.ProjectId);
//                    Console.WriteLine(s.GroupId);
//                    Console.WriteLine(s.Name);
//                    Console.WriteLine(s.Type);
//                }
            
//        }
//        static void PrintAllGroups(AccessContext context)
//        {
   
//                foreach (var s in context.Groups.ToList())
//                {
//                    Console.WriteLine("======");
//                    Console.WriteLine(s.Id);
//                    Console.WriteLine(s.ProjectId);
  
//                    Console.WriteLine(s.Name);
      
//                }
            
//        }
//    }
//}
