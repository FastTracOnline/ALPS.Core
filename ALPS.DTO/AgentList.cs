using System;
using System.Collections;
using System.Collections.Generic;

namespace ALPS.DTO
{
	public class AgentList
	{
        public List<AgentBrief> Agents { get; set; }

        public AgentList()
        {
            Agents = new List<AgentBrief>();
        }
    }

    public class AgentBrief
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryContact { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
    }
}
