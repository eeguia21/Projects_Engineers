using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_Data
{
    public class UserLocationManager
    {
        IDataAccess<PE_UserLocation> contextUserLocation;

        public UserLocationManager(IDataAccess<PE_UserLocation> contextUserLocation)
        {
            this.contextUserLocation = contextUserLocation;
        }
    }
}
