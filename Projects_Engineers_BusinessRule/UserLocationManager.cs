using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class UserLocationManager
    {
        IDataAccess<PE_UserLocation> contextUserLocation;

        public UserLocationManager(IDataAccess<PE_UserLocation> contextUserLocation)
        {
            this.contextUserLocation = contextUserLocation;
        }

        public List<PE_UserLocation> readUsersLocations()
        {
            List<PE_UserLocation> usersLocations = contextUserLocation.Collection().ToList();

            return usersLocations;
        }

        public PE_UserLocation readUserLocation(int Id)
        {
            PE_UserLocation userLocation = contextUserLocation.Find(Id);

            return userLocation;
        }

        public void addUserLocation(PE_UserLocation userLocation)
        {
            contextUserLocation.Insert(userLocation);
            contextUserLocation.Commit();
        }

        public void deleteUserLocation(int Id)
        {
            contextUserLocation.Delete(Id);
            contextUserLocation.Commit();
        }

        public void updateUserLocation(PE_UserLocation userLocation)
        {
            contextUserLocation.Update(userLocation);
            contextUserLocation.Commit();
        }
    }
}
