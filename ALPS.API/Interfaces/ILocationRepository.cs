using ALPS.API.Entities;
using System.Linq;

namespace ALPS.API.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        IQueryable<Location> GetAll(long id);
    }
}
