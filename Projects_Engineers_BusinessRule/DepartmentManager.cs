using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class DepartmentManager
    {
        IDataAccess<PE_CDepartment> contextDepartment;

        public DepartmentManager(IDataAccess<PE_CDepartment> contextDepartment)
        {
            this.contextDepartment = contextDepartment;
        }

        public List<PE_CDepartment> readDepartments()
        {
            List<PE_CDepartment> departments = contextDepartment.Collection().ToList();

            return departments;
        }

        public PE_CDepartment readDepartment(int Id)
        {
            PE_CDepartment department = contextDepartment.Find(Id);

            return department;
        }

        public void addDepartment(PE_CDepartment department)
        {
            contextDepartment.Insert(department);
            contextDepartment.Commit();
        }

        public void deleteDepartment(int Id)
        {
            contextDepartment.Delete(Id);
            contextDepartment.Commit();
        }

        public void updateDepartment(PE_CDepartment department)
        {
            contextDepartment.Update(department);
            contextDepartment.Commit();
        }
    }
}
