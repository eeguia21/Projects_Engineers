using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class CountryManager
    {
        IDataAccess<PE_CCountry> contextCountry;

        public CountryManager(IDataAccess<PE_CCountry> contextCountry)
        {
            this.contextCountry = contextCountry;
        }

        public List<PE_CCountry> readCountries()
        {
            List<PE_CCountry> countries = contextCountry.Collection().ToList();

            return countries;
        }

        public PE_CCountry readCountry(int Id)
        {
            PE_CCountry country = contextCountry.Find(Id);

            return country;
        }

        public void addCountry(PE_CCountry country)
        {
            contextCountry.Insert(country);
            contextCountry.Commit();
        }

        public void deleteCountry(int Id)
        {
            contextCountry.Delete(Id);
            contextCountry.Commit();
        }

        public void updateCountry(PE_CCountry country)
        {
            contextCountry.Update(country);
            contextCountry.Commit();
        }
    }
}
