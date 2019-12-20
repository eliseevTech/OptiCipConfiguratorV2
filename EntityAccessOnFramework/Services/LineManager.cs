using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityAccessOnFramework.Services
{
    public partial class LineManager
    {
        AccessContext _accessContext;

        public LineManager(AccessContext accessContext)
        {
            _accessContext = accessContext;
        }


    



    }



}
