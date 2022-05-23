using Study.DataAccess.Interfaces;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.DataAccess.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IDataAccess dataAccess) : base(dataAccess)
        {

        }
    }
}
