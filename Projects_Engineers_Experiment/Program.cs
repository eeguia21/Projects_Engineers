using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;
using Projects_Engineers_BusinessRule;
using System.Threading;

namespace Projects_Engineers_Experiment
{
    public class TaskScheduler
    {
        private static void getDataUsr(CancellationToken cancelToken)
        {
            DataAccessSQL<PE_User> contextUser = new DataAccessSQL<PE_User>(new Projects_Engineers());
            UserManager objB = new UserManager(contextUser);

            List<PE_User> lst = new List<PE_User>();

            lst = objB.readUsers();

            try
            {
                foreach (PE_User usr in lst)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    Console.WriteLine(usr.Name);
                    Thread.Sleep(1000);
                }
            }
            catch
            {
            }
       }

        private static void getDataState(CancellationToken cancelToken)
        {
            DataAccessSQL<PE_CState> contextState = new DataAccessSQL<PE_CState>(new Projects_Engineers());
            StateManager objS = new StateManager(contextState);
            
            List<PE_CState> lst = new List<PE_CState>();

            lst = objS.readStates(2);

            try
            {
                foreach (PE_CState state in lst)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    Console.WriteLine(state.State);
                    Thread.Sleep(1000);
                }
            }
            catch
            {
            }
        }

        public static void Main(string[] args)
        {
            CancellationTokenSource objCTSU = new CancellationTokenSource();
            CancellationToken tokenU = objCTSU.Token;

            CancellationTokenSource objCTSS = new CancellationTokenSource();
            CancellationToken tokenS = objCTSS.Token;

            tokenU.Register(() => { Console.WriteLine("Cancelation on users"); });
            tokenS.Register(() => { Console.WriteLine("Cancelation on states"); });

            Action actionU = () => getDataUsr(tokenU);
            Task.Factory.StartNew(actionU, tokenU);

            Action actionS = () => getDataState(tokenS);
            Task.Factory.StartNew(actionS, tokenS);

            Console.ReadKey();
            objCTSU.Cancel();
            Console.ReadKey();
            objCTSS.Cancel();

            Console.WriteLine("ENDING TEST");
            Console.ReadKey();
        }
    }
}
