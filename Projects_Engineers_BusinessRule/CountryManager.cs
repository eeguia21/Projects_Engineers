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
    }
}
