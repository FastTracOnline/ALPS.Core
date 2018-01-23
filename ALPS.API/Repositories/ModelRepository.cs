using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class ModelRepository : EFRepository<Model>, IModelRepository
    {
        public ModelRepository(DbContext context) : base(context) { }

        public Model GetModelWithParent(int id)
        {
	        return DbSet.Include("Manufacturer").FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Model> GetModelsForMake(int id)
        {
            return DbSet.Where(m => m.Make_Id == id).ToList();
        }
    }
}
