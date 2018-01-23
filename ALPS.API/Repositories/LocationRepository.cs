using ALPS.API.Entities;
using ALPS.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ALPS.API.Repositories
{
    public class LocationRepository : EFRepository<Location>, ILocationRepository
    {
		public LocationRepository(DbContext context) : base(context) { }

        public IQueryable<Location> GetAll(long id)
        {
            if (id == 0)
                return DbSet;
            else
                return DbSet.Where(p => p.Subscriber.Id == id);
        }
    }
}
