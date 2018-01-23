using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
	        return DbSet;
        }

		public virtual T GetById(long id)
		{
			return DbSet.Find(id);
		}

	    public virtual void Add(T entity)
        {
            //DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            //if (dbEntityEntry.State != EntityState.Detached)
            //{
            //    dbEntityEntry.State = EntityState.Added;
            //}
            //else
            //{
            //    DbSet.Add(entity);
            //}
        }

		public virtual void Update(T entity)
        {
            var type = entity.GetType();
            var dataProperty = type.GetProperty("Id");
            if (dataProperty != null)
            {
                var id = Convert.ToInt32(dataProperty.GetValue(entity));
                if (id > 0)
                {
                    var attachedEntity = DbSet.Find(id);
                    var existingEntity = DbContext.Entry(attachedEntity);
                    existingEntity.CurrentValues.SetValues(entity);
                    existingEntity.State = EntityState.Modified;
                }
            }
        }

		public virtual void Delete(T entity)
        {
        //    DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
        //    if (dbEntityEntry.State != EntityState.Deleted)
        //    {
        //        dbEntityEntry.State = EntityState.Deleted;
        //    }
        //    else
        //    {
        //        DbSet.Attach(entity);
        //        DbSet.Remove(entity);
        //    }
        }

		public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return; // not found; assume already deleted.
            Delete(entity);
        }
    }
}
