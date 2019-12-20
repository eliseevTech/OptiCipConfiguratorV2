using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Services
{
    public class StationManager
    {
        AccessContext _accessContext;
        public StationManager(AccessContext accessContext)
        {
            _accessContext = accessContext;
        }


        public Station AddStation(string name, Group group)
        {
            Station newStation = new Station()
            {
                Name = name,
                ProjectId = group.ProjectId,
                GroupId = group.Id,
                Type = "LIGNE"
            };
            _accessContext.Stations.Add(newStation);
            _accessContext.SaveChanges();
            return newStation;
        }


    }
}
