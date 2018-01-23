using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Interfaces
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        IQueryable<Assignment> GetAll(Company company);
    }
}
