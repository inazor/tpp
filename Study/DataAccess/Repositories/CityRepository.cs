using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.DataAccess.Repositories
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(IDataAccess dataAccess) : base(dataAccess)
        {

        }
    }
}