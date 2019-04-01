using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class ApplicationRoleManager
    {
        IDataAccess<PE_CApplicationRole> contextApplicationRole;

        public ApplicationRoleManager(IDataAccess<PE_CApplicationRole> contextApplicationRole)
        {
            this.contextApplicationRole = contextApplicationRole;
        }

        public List<PE_CApplicationRole> readApplicationRoles()
        {
            List<PE_CApplicationRole> applicationRoles = contextApplicationRole.Collection().ToList();

            return applicationRoles;
        }
    }
}
