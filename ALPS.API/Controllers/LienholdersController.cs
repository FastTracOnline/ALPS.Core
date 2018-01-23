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
	[Route("api/Lienholders")]
	public class LienholdersController : ApiBaseController
	{
		private ALPSContext context;

		public LienholdersController(ALPSContext _context)
		{
			context = _context;
		}

		//[ResourceAuthorize("List", "Lienholders")]
		// GET: api/Lienholders
		[HttpGet]
		public IActionResult GetLienholders()
		{
			var subscriberId = 1;
			var queryList = context.Lienholders
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("Name")
							.ToList<Lienholder>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

			//JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
			//jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
			//jsonFormat.NullValueHandling = NullValueHandling.Ignore;
		}

		// GET: api/Lienholders/5
		[HttpGet("{id}")]
		public ActionResult GetLienholder([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Lienholder = context.Lienholders.Find(id);

			if (Lienholder == null)
			{
				return NotFound();
			}

			return Ok(Map(Lienholder));
		}

		// PUT: api/Lienholders/5
		[HttpPut("{id}")]
		public ActionResult PutLienholder([FromRoute] long id, [FromBody] DTO.Lienholder recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != recordIn.Id)
			{
				return BadRequest();
			}

			if (!LienholderExists(id))
			{
				return NotFound();
			}

			Lienholder currentRecord = context.Lienholders.Find(id);

			if (currentRecord == null)
			{
				return NotFound();
			}

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.Lienholders.Update(currentRecord);

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

		// POST: api/Lienholders
		[HttpPost]
		public ActionResult PostLienholder([FromBody] DTO.Lienholder Lienholder)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var subscriberId = 1;

			Lienholder.Active = true;
			Lienholder.Created = DateTime.UtcNow;
			Lienholder.SubscriberId = subscriberId;

			context.Lienholders.Add(Map(Lienholder));
			context.SaveChanges();

			return CreatedAtAction("GetLienholder", new { id = Lienholder.Id }, Lienholder);
		}

		// DELETE: api/Lienholders/5
		[HttpDelete("{id}")]
		public ActionResult DeleteLienholder([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Lienholder = context.Lienholders.Find(id);
			if (Lienholder == null)
			{
				return NotFound();
			}

			Lienholder.Active = false;
			Lienholder.Updated = DateTime.UtcNow;
			context.Lienholders.Update(Lienholder);

			try
			{
				context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(Lienholder);
		}

		private bool LienholderExists(long id)
		{
			return (context.Lienholders.Find(id) != null);
		}

		internal static DTO.Lienholder Map(Lienholder recordIn)
		{
			if (recordIn == null)
				return null;

			DTO.Lienholder recordOut = new DTO.Lienholder()
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
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static Lienholder Map(DTO.Lienholder recordIn)
		{
			if (recordIn == null)
				return null;

			Lienholder recordOut = new Lienholder()
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
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static List<DTO.Lienholder> Map(List<Lienholder> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Lienholder> listOut = new List<DTO.Lienholder>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<Lienholder> Map(List<DTO.Lienholder> listIn)
		{
			if (listIn == null)
				return null;

			List<Lienholder> listOut = new List<Lienholder>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static void CopyUpdatedFields(DTO.Lienholder recordIn, ref Lienholder currentRecord)
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
			currentRecord.PropertyDaysFree = recordIn.PropertyDaysFree;
			currentRecord.PropertyInitialFee = recordIn.PropertyInitialFee;
			currentRecord.PropertyDailyFee = recordIn.PropertyDailyFee;
			currentRecord.VehicleDaysFree = recordIn.VehicleDaysFree;
			currentRecord.VehicleInitialFee = recordIn.VehicleInitialFee;
			currentRecord.VehicleDailyFee = recordIn.VehicleDailyFee;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
