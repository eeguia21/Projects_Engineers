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

        public PE_CJobTitle readJobTitle(int Id)
        {
            PE_CJobTitle jobTitle = contextJobTitle.Find(Id);

            return jobTitle;
        }

        public void addJobTitle(PE_CJobTitle jobTitle)
        {
            contextJobTitle.Insert(jobTitle);
            contextJobTitle.Commit();
        }

        public void deleteJobTitle(int Id)
        {
            contextJobTitle.Delete(Id);
            contextJobTitle.Commit();
        }

        public void updateJobTitle(PE_CJobTitle jobTitle)
        {
            contextJobTitle.Update(jobTitle);
            contextJobTitle.Commit();
        }
    }
}
