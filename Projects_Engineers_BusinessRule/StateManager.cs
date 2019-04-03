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

        public PE_CState readState(int Id_Country, int Id_State)
        {
            PE_CState state = contextState.Collection().Where(x => x.Id_Country == Id_Country && x.Id == Id_State).FirstOrDefault();

            return state;
        }

        public void addState(PE_CState state)
        {
            contextState.Insert(state);
            contextState.Commit();
        }

        public void deleteState(int Id)
        {
            contextState.Delete(Id);
            contextState.Commit();
        }

        public void updateState(PE_CState state)
        {
            contextState.Update(state);
            contextState.Commit();
        }
    }
}
