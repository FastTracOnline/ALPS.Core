using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class LienholderRepository : EFRepository<Lienholder>, ILienholderRepository
    {
        public LienholderRepository(DbContext context) : base(context) { }

        public IQueryable<Lienholder> GetAll(int id)
        {
            if (id == 0)
                return DbSet;
            else
                return DbSet.Where(p => p.Repossessor.Id == id);
        }
    }
}
