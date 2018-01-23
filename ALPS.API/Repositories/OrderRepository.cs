using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class OrderRepository : EFRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context) { }

        public IQueryable<Order> GetAll(int id)
        {
            if (id == 0)
                return DbSet;
            else
                return DbSet.Where(p => p.Repossessor.Id == id);
        }

        public Order GetOrderWithParents(int id)
        {
	        return DbSet.Include("Repossessor").Include("Lienholder").Include("Location").Include("Vehicle").Include("Vehicle.Manufacturer").FirstOrDefault(m => m.Id == id);
        }
    }
}
