using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Interfaces
{
    public interface IUow
    {
        // Save pending changes to the data store.
        int Commit();

        // Generic Repositories
        //IRepository<Company> Companies { get; }
        //IRepository<PoliceDepartment> PoliceDepartments { get; }
        IRepository<Subscriber> Subscribers { get; }
        ILocationRepository Locations { get; }

        // Custom Repositories
        //ILienholderRepository Lienholders { get; }
        //IRepossessorRepository Repossessors { get; }
        //IAgentRepository Agents { get; }
        //IMakeRepository Makes { get; }
        //IModelRepository Models { get; }
        //IServiceRepository Services { get; }
        //IVendorRepository Vendors { get; }
        //IOrderRepository Orders { get; }
        //IExpenseTypeRepository ExpenseTypes { get; }
    }
}
