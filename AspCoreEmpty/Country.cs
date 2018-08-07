using System;
namespace AspCoreEmpty
{
    public class Country
    {
        public string CountryCode;
        public string CountryName;
        public Country(string code, string name)
        {
            CountryCode = code;
            CountryName = name;
        }
    }
}
