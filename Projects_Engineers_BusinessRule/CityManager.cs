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

        public PE_CCity readCity(int Id_State, int Id_City)
        {
            PE_CCity city = contextCity.Collection().Where(x => x.Id_State == Id_State && x.Id == Id_City).FirstOrDefault();

            return city;
        }

        public void addCity(PE_CCity city)
        {
            contextCity.Insert(city);
            contextCity.Commit();
        }

        public void deleteCity(int Id)
        {
            contextCity.Delete(Id);
            contextCity.Commit();
        }

        public void updateCity(PE_CCity city)
        {
            contextCity.Update(city);
            contextCity.Commit();
        }
    }
}
