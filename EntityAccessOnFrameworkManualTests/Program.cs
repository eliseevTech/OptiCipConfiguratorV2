using Autofac;
using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Services;
using System.Linq;

namespace EntityAccessOnFrameworkManualTests
{
    class Program
    { 
        static void Main(string[] args)
        {            
            //base(new JetConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Test-Project.sep'; providerName=JetEntityFrameworkProvider; Password=SEEME;"), true)
            AccessContext _context = new AccessContext(@"C:/PRJ/c#/OptiCipAdministratorHelper/Config_test.mdb");

            var containerBuilder = new ContainerBuilder();

            containerBuilder.Register(O => new TagManager(_context)).AsSelf().SingleInstance();
            containerBuilder.Register(O => new LineManager(_context)).AsSelf().SingleInstance();
            containerBuilder.Register(O => new LineTagManager(_context)).AsSelf().SingleInstance();
            containerBuilder.Register(O => new StationManager(_context)).AsSelf().SingleInstance();
  
            containerBuilder.RegisterType<ConfigationFacade>().AsSelf();
            IContainer container = containerBuilder.Build();


            var facade = container.Resolve<ConfigationFacade>();


            //_context.Tags.Add(new EntityAccessOnFramework.Models.Tag()
            //{
            //    Name = "Dsa34",
            //    ProjectId = 2,
            //    Label = "Sd",
            //    OpcItem = "dsda",
            //    OpcShortLinkName = "Ds",
            //    Type = "DIG"
            //});
            //_context.SaveChanges();

            facade.TagManager.AddNewTag
                ("test232322",
                "testLabel2",
                "testAlias2",
                TagManager.TagType.digital,
                _context.Projects.First().Id,
                _context.OpcShortLinks.First().Name,
                "Opc Item2");
        }
    }
}
