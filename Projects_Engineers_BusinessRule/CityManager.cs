using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class CityManager
    {
        IDataAccess<PE_CCity> contextCity;

        public CityManager(IDataAccess<PE_CCity> contextCity)
        {
            this.contextCity = contextCity;
        }

        public List<PE_CCity> readCities(int Id_State)
        {
            List<PE_CCity> cities = contextCity.Collection().Where(x => x.Id_State == Id_State).ToList();

            return cities;
        }
    }
}
