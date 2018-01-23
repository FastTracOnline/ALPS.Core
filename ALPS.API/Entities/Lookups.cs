using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class Lookups
    {
        public IList<Agent> Agents { get; set; }
        public IList<Lienholder> Lienholders { get; set; }
        public IList<Repossessor> Repossessors { get; set; }
        public IList<Vendor> Vendors { get; set; }
    }
}
