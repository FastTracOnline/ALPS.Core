using ALPS.API.Data;
using ALPS.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ALPS.API.Controllers
{
	[Produces("application/json")]
    [Route("api/Agents")]
    public class AgentsController : ApiBaseController
    {
        private ALPSContext context;

        public AgentsController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Agents")]
        // GET: api/Agents
        [HttpGet]
        public IActionResult GetAgents()
        {
			var subscriberId = 1;
			var queryList = context.Agents
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("LastName,FirstName")
							.ToList<Agent>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public ActionResult GetAgent([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Agent = context.Agents.Find(id);

            if (Agent == null)
            {
                return NotFound();
            }

            return Ok(Map(Agent));
        }

        // PUT: api/Agents/5
        [HttpPut("{id}")]
        public ActionResult PutAgent([FromRoute] long id, [FromBody] DTO.Agent recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!AgentExists(id))
            {
                return NotFound();
            }

            Agent currentRecord = context.Agents.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.Agents.Update(currentRecord);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Agents
        [HttpPost]
        public ActionResult PostAgent([FromBody] DTO.Agent Agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

            Agent.Active = true;
            Agent.Created = DateTime.UtcNow;
            Agent.SubscriberId = subscriberId;

            context.Agents.Add(Map(Agent));
            context.SaveChanges();

            return CreatedAtAction("GetAgent", new { id = Agent.Id }, Agent);
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAgent([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Agent = context.Agents.Find(id);
            if (Agent == null)
            {
                return NotFound();
            }

            Agent.Active = false;
            Agent.Updated = DateTime.UtcNow;
            context.Agents.Update(Agent);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(Agent);
        }

        private bool AgentExists(long id)
        {
            return (context.Agents.Find(id) != null);
        }

        internal static DTO.Agent Map(Agent recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Agent recordOut = new DTO.Agent()
            {
                Id = recordIn.Id,
                FirstName = recordIn.FirstName,
                LastName = recordIn.LastName,
                Address = recordIn.Address,
                City = recordIn.City,
                State = recordIn.State,
                Zip = recordIn.Zip,
                Phone = recordIn.Phone,
                Mobile = recordIn.Mobile,
                Fax = recordIn.Fax,
                Email = recordIn.Email,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				AgentType = recordIn.AgentType,
				VolRepoPaid = recordIn.VolRepoPaid,
				InvolRepoPaid = recordIn.InvolRepoPaid,
				TracePaid = recordIn.TracePaid,
				SubscriberId = recordIn.SubscriberId,
                Subscriber = SubscribersController.Map(recordIn.Subscriber)
            };

            return recordOut;
        }

        internal static Agent Map(DTO.Agent recordIn)
        {
            if (recordIn == null)
                return null;

            Agent recordOut = new Agent()
            {
                Id = recordIn.Id,
                FirstName = recordIn.FirstName,
                LastName = recordIn.LastName,
                Address = recordIn.Address,
                City = recordIn.City,
                State = recordIn.State,
                Zip = recordIn.Zip,
                Phone = recordIn.Phone,
                Mobile = recordIn.Mobile,
                Fax = recordIn.Fax,
                Email = recordIn.Email,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				AgentType = recordIn.AgentType,
				VolRepoPaid = recordIn.VolRepoPaid,
				InvolRepoPaid = recordIn.InvolRepoPaid,
				TracePaid = recordIn.TracePaid,
				SubscriberId = recordIn.SubscriberId,
                Subscriber = SubscribersController.Map(recordIn.Subscriber)
            };

            return recordOut;
        }

		internal List<DTO.Agent> Map(List<Agent> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Agent> listOut = new List<DTO.Agent>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<Agent> Map(List<DTO.Agent> listIn)
		{
			if (listIn == null)
				return null;

			List<Agent> listOut = new List<Agent>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Agent recordIn, ref Agent currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.FirstName = recordIn.FirstName;
			currentRecord.LastName = recordIn.LastName;
			currentRecord.Address = recordIn.Address;
			currentRecord.City = recordIn.City;
			currentRecord.State = recordIn.State;
			currentRecord.Zip = recordIn.Zip;
			currentRecord.Phone = recordIn.Phone;
			currentRecord.Mobile = recordIn.Mobile;
			currentRecord.Fax = recordIn.Fax;
			currentRecord.Email = recordIn.Email;
			currentRecord.Notes = recordIn.Notes;

			currentRecord.AgentType = recordIn.AgentType;
			currentRecord.VolRepoPaid = recordIn.VolRepoPaid;
			currentRecord.InvolRepoPaid = recordIn.InvolRepoPaid;
			currentRecord.TracePaid = recordIn.TracePaid;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
