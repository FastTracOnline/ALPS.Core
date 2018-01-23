using ALPS.API.Data;
using ALPS.API.Entities;
using ALPS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ALPS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Dashboard")]
    public class DashboardController : ApiBaseController
    {
		private ALPSContext context;

		public DashboardController(ALPSContext _context)
		{
			context = _context;
		}

		// GET: api/Dashboard
		[HttpGet]
		public IActionResult Get()
		{
			var subscriberId = 1;
			DTO.Dashboard dashboard = new DTO.Dashboard();

			dashboard.Agents_Active = context.Agents
							.Where(c => c.SubscriberId == subscriberId && c.Active == true)
							.Count();

			dashboard.Lienholders_Active = context.Lienholders
							.Where(c => c.SubscriberId == subscriberId && c.Active == true)
							.Count();

			dashboard.Orders_New = context.Orders
							.Where(c => c.SubscriberId == subscriberId && c.OrderStatus == OrderStatus.New)
							.Count();

			dashboard.Orders_Working = context.Orders
							.Where(c => c.SubscriberId == subscriberId && c.OrderStatus == OrderStatus.Working)
							.Count();

			dashboard.Orders_Repossessed = context.Orders
							.Where(c => c.SubscriberId == subscriberId && c.OrderStatus == OrderStatus.Repossessed)
							.Count();

			dashboard.Orders_Billable = context.Orders
							.Where(c => c.SubscriberId == subscriberId && c.OrderStatus == OrderStatus.Repossessed)
							.Count();

			return Ok(dashboard);
		}
	}
}