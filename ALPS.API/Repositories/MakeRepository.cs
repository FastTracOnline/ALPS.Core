using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class MakeRepository : EFRepository<Make>, IMakeRepository
    {
        public MakeRepository(DbContext context) : base(context) { }

        public Make GetMakeWithChildren(int id)
        {
	        return DbSet.Include("Models").FirstOrDefault(m => m.Id == id);
        }
    }
}
