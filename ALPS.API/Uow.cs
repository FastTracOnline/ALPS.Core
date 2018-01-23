using ALPS.API.Entities;
using ALPS.API.Interfaces;
using System;

namespace ALPS.API
{
    /// <summary>
    /// The "Unit of Work" pattern
    ///     1) decouples the repositories from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages multiple updates as a single UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "Uow" serves as a facade for querying and saving to the database.
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Lienholder"/>.
    /// A repository typically exposes CRUD methods (Create, Read, Update, Delete)
    /// if those features are supported.
    /// The repositories rely on their parent Uow to provide the interface to the
    /// data layer (which is the EF DbContext in this instance).
    /// </remarks>
    public class Uow : IUow, IDisposable
    {
        public Uow(IRepositoryProvider repositoryProvider)
        {
            //System.Diagnostics.Debug.WriteLine("Creating Uow");
            //CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        // Generic Repositories
        public IRepository<Subscriber> Subscribers { get { return GetStandardRepo<Subscriber>(); } }
        //public IRepository<Company> Companies { get { return GetStandardRepo<Company>(); } }
        //public IRepository<PoliceDepartment> PoliceDepartments { get { return GetStandardRepo<PoliceDepartment>(); } }

        // Customized Repositories
        //public ILienholderRepository Lienholders { get { return GetRepo<ILienholderRepository>(); } }
        //public IRepossessorRepository Repossessors { get { return GetRepo<IRepossessorRepository>(); } }
        //public IAgentRepository Agents { get { return GetRepo<IAgentRepository>(); } }
        //public IMakeRepository Makes { get { return GetRepo<IMakeRepository>(); } }
        //public IModelRepository Models { get { return GetRepo<IModelRepository>(); } }
        //public IOrderRepository Orders { get { return GetRepo<IOrderRepository>(); } }
        public ILocationRepository Locations { get { return GetRepo<ILocationRepository>(); } }
        //public IServiceRepository Services { get { return GetRepo<IServiceRepository>(); } }
        //public IVendorRepository Vendors { get { return GetRepo<IVendorRepository>(); } }
        //public IExpenseTypeRepository ExpenseTypes { get { return GetRepo<IExpenseTypeRepository>(); } }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public int Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committing");
            return DbContext.SaveChanges();
        }

        //protected void CreateDbContext()
        //{
        //    //System.Diagnostics.Debug.WriteLine("Creating DbContext");
        //    DbContext = new ALPSContext();

        //    // Do NOT enable proxied entities, else serialization fails
        //    DbContext.Configuration.ProxyCreationEnabled = false;

        //    // Load navigation properties explicitly (avoid serialization trouble)
        //    DbContext.Configuration.LazyLoadingEnabled = false;

        //    // Because Web API will perform validation, we don't need/want EF to do so
        //    DbContext.Configuration.ValidateOnSaveEnabled = false;

        //    //DbContext.Configuration.AutoDetectChangesEnabled = false;
        //    // We won't use this performance tweak because we don't need 
        //    // the extra performance and, when autodetect is false,
        //    // we'd have to be careful. We're not being that careful.
        //}

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private ALPSContext DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
