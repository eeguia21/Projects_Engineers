using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Projects_Engineers_BusinessRule;
using Projects_Engineers_Data;
using Quartz;
using Quartz.Impl;

namespace Scheduler
{
    public class SchedulerTest
    {
        static void Main(string[] args)
        {
            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            IScheduler sched = schedFact.GetScheduler().GetAwaiter().GetResult();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(5)
                  .RepeatForever())
              .Build();

            sched.ScheduleJob(job, trigger);

            Console.ReadLine();
        }
    }

    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Action actionUs = () => getDataUsr();
            Task t1 = new Task(actionUs);
            t1.Start();

            return t1;
        }

        private static void getDataUsr()
        {
            DataAccessSQL<PE_User> contextUser = new DataAccessSQL<PE_User>(new Projects_Engineers());
            UserManager objB = new UserManager(contextUser);

            List<PE_User> lst = new List<PE_User>();

            lst = objB.readUsers().Where(x => x.Name.Contains("Lizbeth")).ToList();

            try
            {
                foreach (PE_User usr in lst)
                {
                    Console.WriteLine(usr.Name);
                }
            }
            catch
            {
            }
        }
    }
}
