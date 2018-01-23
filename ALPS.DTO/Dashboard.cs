using System;
using System.Collections.Generic;
using System.Text;

namespace ALPS.DTO
{
	public class Dashboard
	{
		public int Orders_New { get; set; }
		public int Orders_Working { get; set; }
		public int Orders_Repossessed { get; set; }
		public int Orders_Billable { get; set; }
		public int Orders_NotPaid { get; set; }
		public int Agents_Active { get; set; }
		public int Lienholders_Active { get; set; }
	}
}
