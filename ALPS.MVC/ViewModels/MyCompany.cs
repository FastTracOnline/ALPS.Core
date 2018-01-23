using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALPS.MVC.ViewModels
{
	// This is a read-only model.  The corresponding view displays some coimpany information and buttons to select actions.
    public class MyCompany
    {
		public string Name { get; set; }
		public int ActiveAgents { get; set; }
		public int AllAgents { get; set; }
		public int ActiveClients { get; set; }
		public int AllClients { get; set; }
		public int ActiveOrders { get; set; }
		public int AllOrders { get; set; }
	}
}
