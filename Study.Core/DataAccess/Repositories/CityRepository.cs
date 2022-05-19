using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;

namespace Study.DataAccess.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDataAccess dataAccess) : base(dataAccess)
        {

        }
    }
}