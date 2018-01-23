using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class RepossessorRepository : EFRepository<Repossessor>, IRepossessorRepository
    {
        public RepossessorRepository(DbContext context) : base(context) { }

        public Repossessor GetRepossessorWithChildren(int id)
        {
	        return DbSet.Include("Agents").Include("Locations").Include("Services").FirstOrDefault(m => m.Id == id);
        }
    }
}
