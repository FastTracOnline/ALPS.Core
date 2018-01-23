using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALPS.MVC.ViewModels
{
    public class PoliceDepartment : Company
    {
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}
