using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class StateManager
    {
        IDataAccess<PE_CState> contextState;

        public StateManager(IDataAccess<PE_CState> contextState)
        {
            this.contextState = contextState;
        }

        public List<PE_CState> readStates(int Id_Country)
        {
            List<PE_CState> states = contextState.Collection().Where(x => x.Id_Country == Id_Country).ToList();

            return states;
        }
    }
}
