using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace AspCoreEmpty
{
    public class CountryRepository : ICountryRepository
    {
        private static IList<Country> _countries;

        public IQueryable<Country> All()
        {
            EnsureCountriesAreLoaded();
            return _countries.AsQueryable();
        }

        private void EnsureCountriesAreLoaded()
        {
            if (_countries == null)
                _countries = LoadCountriesFromStream();
        }

        private IList<Country> LoadCountriesFromStream()
        {
            var json = File.ReadAllText("countries.json");
            var countries = JsonConvert.DeserializeObject<Country[]>(json);
            return countries.OrderBy(c=>c.CountryName).ToList();
        }

        public IQueryable<Country> AllBy(string filter)
        {
            return string.IsNullOrEmpty(filter) 
                         ?
                         All()
                             : 
                         (All()
                          .Where(c => c.CountryName.ToLower().StartsWith(filter, StringComparison.CurrentCultureIgnoreCase)));                     
        }

        public Country Find(string code)
        {
            return (from c in All()
                    where c.CountryCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                    select c).FirstOrDefault();
        }
    }
}
