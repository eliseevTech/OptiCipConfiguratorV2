using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Services
{
    public class GroupManager
    {
        AccessContext _accessContext;
        public GroupManager(AccessContext accessContext)
        {
            _accessContext = accessContext;
        }


        public Group AddGroup(string name)
        {
            Group group = new Group()
            {
                Name = name,
                ProjectId = _accessContext.Projects.First().Id,                
            };
            _accessContext.Groups.Add(group);
            _accessContext.SaveChanges();
            return group;
        }


    }
}
