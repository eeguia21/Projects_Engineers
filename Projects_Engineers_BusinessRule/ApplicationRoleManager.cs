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

        public PE_CApplicationRole readApplicationRole(int Id)
        {
            PE_CApplicationRole appRole = contextApplicationRole.Find(Id);

            return appRole;
        }

        public void addApplicationRole(PE_CApplicationRole appRole)
        {
            contextApplicationRole.Insert(appRole);
            contextApplicationRole.Commit();
        }

        public void deleteApplicationRole(int Id)
        {
            contextApplicationRole.Delete(Id);
            contextApplicationRole.Commit();
        }

        public void updateApplicationRole(PE_CApplicationRole appRole)
        {
            contextApplicationRole.Update(appRole);
            contextApplicationRole.Commit();
        }
    }
}
