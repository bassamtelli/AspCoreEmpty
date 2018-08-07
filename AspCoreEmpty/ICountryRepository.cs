using System;
using System.Linq;
namespace AspCoreEmpty
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
