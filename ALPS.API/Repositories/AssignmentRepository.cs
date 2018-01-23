using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
	public class AssignmentRepository : EFRepository<Assignment>, IAssignmentRepository
	{
		public AssignmentRepository(DbContext context) : base(context) { }

		public IQueryable<Assignment> GetAll(Company company)
		{
			int id = 0;

			if (company is Lienholder)
			{
				id = (company as Lienholder).Id;
				return DbSet.Include("Lienholder").Where(p => p.Lienholder.Id == id);
			}
			else if (company is Repossessor)
			{
				id = (company as Repossessor).Id;
				return DbSet.Include("Repossessor").Where(p => p.Repossessor.Id == id);
			}

			return null;
		}
	}
}
