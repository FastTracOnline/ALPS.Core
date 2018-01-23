using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class ExpenseTypeRepository : EFRepository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(DbContext context) : base(context) { }

        public IQueryable<ExpenseType> GetAll(int id)
        {
            if (id == 0)
                return DbSet;
            else
                return DbSet.Where(p => p.Repossessor.Id == id);
        }
    }
}
