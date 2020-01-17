using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using NLog;

namespace OptiCipAdministratorHelper2.Services
{
    public class WindowsService
    {
        PrincipalContext _principalContext;

        public WindowsService()
        {          
            _principalContext = new PrincipalContext(ContextType.Machine);
        }

        public bool CheckOpticipUsersGroup()
        {
            if (!CheckOneGroup("OPTICIP_ADMINISTRATORS") || !CheckOneGroup("OPTICIP_USERS") || !CheckOneGroup("OPTICIP_MANAGERS"))
            {
                return false;
            }
            return true;
        }


        public bool CheckOneGroup(string groupName)
        {
            try
            {
                GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(_principalContext, groupName);         
                if (oGroupPrincipal != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public bool AddOptiCipGroups()
        {
            if (   !AddGroup("OPTICIP_ADMINISTRATORS", "Group for Opticip software")
                || !AddGroup("OPTICIP_USERS", "Group for Opticip software")
                || !AddGroup("OPTICIP_MANAGERS", "Group for Opticip software"))
            {
                return false;
            }
            return true;
            }


        private bool AddGroup(string name, string description)
        {
            if (CheckOneGroup(name))
            {
                return true;
            }
            try
            {
                GroupPrincipal groupPrincipal = new GroupPrincipal(_principalContext);
                groupPrincipal.GroupScope = System.DirectoryServices.AccountManagement.GroupScope.Local;
                groupPrincipal.Name = name;
                groupPrincipal.Description = description;
                groupPrincipal.Save();
                return true;
            }
            catch
            {
                return false;
            }
 
        }


    }
}
