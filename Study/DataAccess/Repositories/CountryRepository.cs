using Study.DataAccess.Interfaces;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.DataAccess.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IDataAccess dataAccess) : base(dataAccess)
        {

        }
    }
}