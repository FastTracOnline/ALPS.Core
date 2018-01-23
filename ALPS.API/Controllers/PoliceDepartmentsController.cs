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
	[Route("api/PoliceDepartments")]
	public class PoliceDepartmentsController : ApiBaseController
	{
		private ALPSContext context;

		public PoliceDepartmentsController(ALPSContext _context)
		{
			context = _context;
		}

		//[ResourceAuthorize("List", "PoliceDepartments")]
		// GET: api/PoliceDepartments
		[HttpGet]
		public IActionResult GetPoliceDepartments()
		{
			var subscriberId = 1;
			var queryList = context.PoliceDepartments
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("Name")
							.ToList<PoliceDepartment>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

			//JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
			//jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
			//jsonFormat.NullValueHandling = NullValueHandling.Ignore;
		}

		// GET: api/PoliceDepartments/5
		[HttpGet("{id}")]
		public ActionResult GetPoliceDepartment([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var PoliceDepartment = context.PoliceDepartments.Find(id);

			if (PoliceDepartment == null)
			{
				return NotFound();
			}

			return Ok(Map(PoliceDepartment));
		}

		// PUT: api/PoliceDepartments/5
		[HttpPut("{id}")]
		public ActionResult PutPoliceDepartment([FromRoute] long id, [FromBody] DTO.PoliceDepartment recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != recordIn.Id)
			{
				return BadRequest();
			}

			if (!PoliceDepartmentExists(id))
			{
				return NotFound();
			}

			PoliceDepartment currentRecord = context.PoliceDepartments.Find(id);

			if (currentRecord == null)
			{
				return NotFound();
			}

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.PoliceDepartments.Update(currentRecord);

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

		// POST: api/PoliceDepartments
		[HttpPost]
		public ActionResult PostPoliceDepartment([FromBody] DTO.PoliceDepartment recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var subscriberId = 1;

			recordIn.Active = true;
			recordIn.Created = DateTime.UtcNow;
			recordIn.SubscriberId = subscriberId;

			context.PoliceDepartments.Add(Map(recordIn));
			context.SaveChanges();

			return CreatedAtAction("GetPoliceDepartment", new { id = recordIn.Id }, recordIn);
		}

		// DELETE: api/PoliceDepartments/5
		[HttpDelete("{id}")]
		public ActionResult DeletePoliceDepartment([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var PoliceDepartment = context.PoliceDepartments.Find(id);
			if (PoliceDepartment == null)
			{
				return NotFound();
			}

			PoliceDepartment.Active = false;
			PoliceDepartment.Updated = DateTime.UtcNow;
			context.PoliceDepartments.Update(PoliceDepartment);

			try
			{
				context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(PoliceDepartment);
		}

		private bool PoliceDepartmentExists(long id)
		{
			return (context.PoliceDepartments.Find(id) != null);
		}

		internal static DTO.PoliceDepartment Map(PoliceDepartment recordIn)
		{
			if (recordIn == null)
				return null;

			DTO.PoliceDepartment recordOut = new DTO.PoliceDepartment()
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
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static PoliceDepartment Map(DTO.PoliceDepartment recordIn)
		{
			if (recordIn == null)
				return null;

			PoliceDepartment recordOut = new PoliceDepartment()
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
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static List<DTO.PoliceDepartment> Map(List<PoliceDepartment> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.PoliceDepartment> listOut = new List<DTO.PoliceDepartment>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<PoliceDepartment> Map(List<DTO.PoliceDepartment> listIn)
		{
			if (listIn == null)
				return null;

			List<PoliceDepartment> listOut = new List<PoliceDepartment>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal void CopyUpdatedFields(DTO.PoliceDepartment recordIn, ref PoliceDepartment currentRecord)
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

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
