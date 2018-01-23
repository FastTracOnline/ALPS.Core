using ALPS.API.Data;
using ALPS.Common;
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
	[Route("api/Contacts")]
	public class ContactsController : ApiBaseController
	{
		private ALPSContext context;

		public ContactsController(ALPSContext _context)
		{
			context = _context;
		}

		//[ResourceAuthorize("List", "Contacts")]
		// GET: api/Contacts
		[HttpGet]
		public IActionResult GetContacts()
		{
			var subscriberId = 1;
			var queryList = context.Contacts
							.Where(c => c.SubscriberId == subscriberId && c.RelationToDebtor != RelationshipType.Debtor)
							.OrderBy("LastName,FirstName")
							.ToList<Contact>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

			//JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
			//jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
			//jsonFormat.NullValueHandling = NullValueHandling.Ignore;
		}

		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public ActionResult GetContact([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Contact = context.Contacts.Find(id);

			if (Contact == null || Contact.RelationToDebtor == RelationshipType.Debtor)
			{
				return NotFound();
			}

			return Ok(Map(Contact));
		}

		// PUT: api/Contacts/5
		[HttpPut("{id}")]
		public ActionResult PutContact([FromRoute] long id, [FromBody] DTO.Contact recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != recordIn.Id)
			{
				return BadRequest();
			}

			if (!ContactExists(id))
			{
				return NotFound();
			}

			Contact currentRecord = context.Contacts.Find(id);

			if (currentRecord == null || currentRecord.RelationToDebtor == RelationshipType.Debtor)
			{
				return NotFound();
			}

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.Contacts.Update(currentRecord);

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

		// POST: api/Contacts
		[HttpPost]
		public ActionResult PostContact([FromBody] DTO.Contact contact)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (contact.RelationToDebtor == RelationshipType.Debtor)
				return BadRequest("Cannot save Debtors here");

			var subscriberId = 1;

			contact.Active = true;
			contact.SubscriberId = subscriberId;
			contact.Created = DateTime.UtcNow;

			context.Contacts.Add(Map(contact));
			context.SaveChanges();

			return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
		}

		// DELETE: api/Contacts/5
		[HttpDelete("{id}")]
		public ActionResult DeleteContact([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Contact = context.Contacts.Find(id);

			if (Contact == null || Contact.RelationToDebtor == RelationshipType.Debtor)
			{
				return NotFound();
			}

			Contact.Active = false;
			Contact.Updated = DateTime.UtcNow;
			context.Contacts.Update(Contact);

			try
			{
				context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(Contact);
		}

		private bool ContactExists(long id)
		{
			var Contact = context.Contacts.Find(id);
			return (Contact != null && Contact.RelationToDebtor == RelationshipType.Debtor);
		}

		internal static DTO.Contact Map(Contact recordIn)
		{
			if (recordIn == null)
				return null;

			DTO.Contact recordOut = new DTO.Contact()
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
				RelationToDebtor = recordIn.RelationToDebtor,
				SSN = recordIn.SSN,
				LicenseNumber = recordIn.LicenseNumber,
				LicenseState = recordIn.LicenseState,
				EmployerId = recordIn.EmployerId,
				Employer = EmployersController.Map(recordIn.Employer)
			};

			return recordOut;
		}

		internal static Contact Map(DTO.Contact recordIn)
		{
			if (recordIn == null)
				return null;

			Contact recordOut = new Contact()
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
				RelationToDebtor = recordIn.RelationToDebtor,
				SSN = recordIn.SSN,
				LicenseNumber = recordIn.LicenseNumber,
				LicenseState = recordIn.LicenseState,
				EmployerId = recordIn.EmployerId,
				Employer = EmployersController.Map(recordIn.Employer)
			};

			return recordOut;
		}

		internal static List<DTO.Contact> Map(List<Contact> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Contact> listOut = new List<DTO.Contact>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<Contact> Map(List<DTO.Contact> listIn)
		{
			if (listIn == null)
				return null;

			List<Contact> listOut = new List<Contact>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Contact recordIn, ref Contact currentRecord)
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
			currentRecord.SSN = recordIn.SSN;
			currentRecord.LicenseNumber = recordIn.LicenseNumber;
			currentRecord.LicenseState = recordIn.LicenseState;
			currentRecord.EmployerId = recordIn.EmployerId;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
