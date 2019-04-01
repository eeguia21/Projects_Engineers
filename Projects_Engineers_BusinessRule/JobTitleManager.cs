using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class JobTitleManager
    {
        IDataAccess<PE_CJobTitle> contextJobTitle;

        public JobTitleManager(IDataAccess<PE_CJobTitle> contextJobTitle)
        {
            this.contextJobTitle = contextJobTitle;
        }

        public List<PE_CJobTitle> readJobTitles()
        {
            List<PE_CJobTitle> jobTitles = contextJobTitle.Collection().ToList();

            return jobTitles;
        }
    }
}
