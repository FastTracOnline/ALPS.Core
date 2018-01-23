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
    [Route("api/Subscribers")]
    public class SubscribersController : ApiBaseController
    {
        private ALPSContext context;

        public SubscribersController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Subscribers")]
        // GET: api/Subscribers
        [HttpGet]
        public IActionResult GetSubscribers()
        {
			var queryList = context.Subscribers
							.OrderBy("Name")
							.ToList<Subscriber>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/Subscribers/5
        [HttpGet("{id}")]
        public ActionResult GetSubscriber([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = context.Subscribers.Find(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(Map(subscriber));
        }

        // PUT: api/Subscribers/5
        [HttpPut("{id}")]
        public ActionResult PutSubscriber([FromRoute] long id, [FromBody] DTO.Subscriber recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!SubscriberExists(id))
            {
                return NotFound();
            }
            
            Subscriber currentRecord = context.Subscribers.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.Subscribers.Update(currentRecord);

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

        // POST: api/Subscribers
        [HttpPost]
        public ActionResult PostSubscriber([FromBody] DTO.Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            subscriber.Active = true;
            subscriber.Created = DateTime.UtcNow;
            context.Subscribers.Add(Map(subscriber));
            context.SaveChanges();

            return CreatedAtAction("GetSubscriber", new { id = subscriber.Id }, subscriber);
        }

        // DELETE: api/Subscribers/5
        [HttpDelete("{id}")]
        public ActionResult DeleteSubscriber([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = context.Subscribers.Find(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            subscriber.Active = false;
            subscriber.Updated = DateTime.UtcNow;
            context.Subscribers.Update(subscriber);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(subscriber);
        }

        private bool SubscriberExists(long id)
        {
            return (context.Subscribers.Find(id) != null);
        }

        internal static DTO.Subscriber Map(Subscriber recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Subscriber recordOut = new DTO.Subscriber()
            {
                Id = recordIn.Id,
                Name = recordIn.Name,
                PrimaryContact = recordIn.PrimaryContact,
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
				Type = recordIn.Type,
				Balance = recordIn.Balance,
				TenantName = recordIn.TenantName,
			};

            return recordOut;
        }

        internal static Subscriber Map(DTO.Subscriber recordIn)
        {
            if (recordIn == null)
                return null;

            Subscriber recordOut = new Subscriber()
            {
                Id = recordIn.Id,
                Name = recordIn.Name,
                PrimaryContact = recordIn.PrimaryContact,
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
				Type = recordIn.Type,
				Balance = recordIn.Balance,
				TenantName = recordIn.TenantName,
			};

            return recordOut;
        }

		internal static List<DTO.Subscriber> Map(List<Subscriber> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Subscriber> listOut = new List<DTO.Subscriber>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<Subscriber> Map(List<DTO.Subscriber> listIn)
		{
			if (listIn == null)
				return null;

			List<Subscriber> listOut = new List<Subscriber>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal void CopyUpdatedFields(DTO.Subscriber recordIn, ref Subscriber currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.Name = recordIn.Name;
			currentRecord.PrimaryContact = recordIn.PrimaryContact;
			currentRecord.Address = recordIn.Address;
			currentRecord.City = recordIn.City;
			currentRecord.State = recordIn.State;
			currentRecord.Zip = recordIn.Zip;
			currentRecord.Phone = recordIn.Phone;
			currentRecord.Mobile = recordIn.Mobile;
			currentRecord.Fax = recordIn.Fax;
			currentRecord.Email = recordIn.Email;
			currentRecord.Notes = recordIn.Notes;

			currentRecord.Balance = recordIn.Balance;
			currentRecord.TenantName = recordIn.TenantName;
			currentRecord.Type = recordIn.Type;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
