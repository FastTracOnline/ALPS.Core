using ALPS.API.Data;
using ALPS.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;

namespace ALPS.API.Controllers
{
	[Produces("application/json")]
	[Route("api/Employers")]
	public class EmployersController : ApiBaseController
	{
		private ALPSContext context;

		public EmployersController(ALPSContext _context)
		{
			context = _context;
		}

		//[ResourceAuthorize("List", "Employers")]
		// GET: api/Employers
		[HttpGet]
		public IActionResult GetEmployers()
		{
			return BadRequest("Not Implemented");
		}

		// GET: api/Employers/5
		[HttpGet("{id}")]
		public ActionResult GetEmployer([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Employer = context.Employers.Find(id);

			if (Employer == null)
			{
				return NotFound();
			}

			return Ok(Map(Employer));
		}

		// PUT: api/Employers/5
		[HttpPut("{id}")]
		public ActionResult PutEmployer([FromRoute] long id, [FromBody] DTO.Employer recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != recordIn.Id)
			{
				return BadRequest();
			}

			if (!EmployerExists(id))
			{
				return NotFound();
			}

			Employer currentRecord = context.Employers.Find(id);

			if (currentRecord == null)
			{
				return NotFound();
			}

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.Employers.Update(currentRecord);

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

		// POST: api/Employers
		[HttpPost]
		public ActionResult PostEmployer([FromBody] DTO.Employer Employer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var subscriberId = 1;

			Employer.Active = true;
			Employer.Created = DateTime.UtcNow;
			Employer.SubscriberId = subscriberId;

			context.Employers.Add(Map(Employer));
			context.SaveChanges();

			return CreatedAtAction("GetEmployer", new { id = Employer.Id }, Employer);
		}

		// DELETE: api/Employers/5
		[HttpDelete("{id}")]
		public ActionResult DeleteEmployer([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Employer = context.Employers.Find(id);
			if (Employer == null)
			{
				return NotFound();
			}

			Employer.Active = false;
			Employer.Updated = DateTime.UtcNow;
			context.Employers.Update(Employer);

			try
			{
				context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(Employer);
		}

		private bool EmployerExists(long id)
		{
			return (context.Employers.Find(id) != null);
		}

		internal static DTO.Employer Map(Employer recordIn)
		{
			if (recordIn == null)
				return null;

			DTO.Employer recordOut = new DTO.Employer()
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
				EmploymentType = recordIn.EmploymentType,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static Employer Map(DTO.Employer recordIn)
		{
			if (recordIn == null)
				return null;

			Employer recordOut = new Employer()
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
				EmploymentType = recordIn.EmploymentType,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static List<DTO.Employer> Map(List<Employer> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Employer> listOut = new List<DTO.Employer>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<Employer> Map(List<DTO.Employer> listIn)
		{
			if (listIn == null)
				return null;

			List<Employer> listOut = new List<Employer>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static void CopyUpdatedFields(DTO.Employer recordIn, ref Employer currentRecord)
		{
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
			currentRecord.EmploymentType = recordIn.EmploymentType;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
