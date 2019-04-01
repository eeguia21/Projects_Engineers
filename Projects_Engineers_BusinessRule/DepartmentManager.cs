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
    }
}
