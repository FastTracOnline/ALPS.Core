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
	[Route("api/Services")]
	public class ServicesController : ApiBaseController
	{
		private ALPSContext context;

		public ServicesController(ALPSContext _context)
		{
			context = _context;
		}

		//[ResourceAuthorize("List", "Services")]
		// GET: api/Services
		[HttpGet]
		public IActionResult GetServices()
		{
			var subscriberId = 1;

			var queryList = context.Services
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("Description")
							.ToList<Service>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

			//JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
			//jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
			//jsonFormat.NullValueHandling = NullValueHandling.Ignore;
		}

		// GET: api/Services/5
		[HttpGet("{id}")]
		public ActionResult GetService([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Service = context.Services.Find(id);

			if (Service == null)
			{
				return NotFound();
			}

			return Ok(Map(Service));
		}

		// PUT: api/Services/5
		[HttpPut("{id}")]
		public ActionResult PutService([FromRoute] long id, [FromBody] DTO.Service recordIn)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != recordIn.Id)
			{
				return BadRequest();
			}

			if (!ServiceExists(id))
			{
				return NotFound();
			}

			Service currentRecord = context.Services.Find(id);

			if (currentRecord == null)
			{
				return NotFound();
			}

			CopyUpdatedFields(recordIn, ref currentRecord);
			context.Services.Update(currentRecord);

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

		// POST: api/Services
		[HttpPost]
		public ActionResult PostService([FromBody] DTO.Service Service)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var subscriberId = 1;

			Service.Active = true;
			Service.Created = DateTime.UtcNow;
			Service.SubscriberId = subscriberId;

			context.Services.Add(Map(Service));
			context.SaveChanges();

			return CreatedAtAction("GetService", new { id = Service.Id }, Service);
		}

		// DELETE: api/Services/5
		[HttpDelete("{id}")]
		public ActionResult DeleteService([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Service = context.Services.Find(id);
			if (Service == null)
			{
				return NotFound();
			}

			Service.Active = false;
			Service.Updated = DateTime.UtcNow;
			context.Services.Update(Service);

			try
			{
				context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(Service);
		}

		private bool ServiceExists(long id)
		{
			return (context.Services.Find(id) != null);
		}

		internal static DTO.Service Map(Service recordIn)
		{
			if (recordIn == null)
				return null;

			DTO.Service recordOut = new DTO.Service()
			{
				Id = recordIn.Id,
				ServiceType = recordIn.ServiceType,
				FeeType = recordIn.FeeType,
				Description = recordIn.Description,
				BasePrice = recordIn.BasePrice,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static Service Map(DTO.Service recordIn)
		{
			if (recordIn == null)
				return null;

			Service recordOut = new Service()
			{
				Id = recordIn.Id,
				ServiceType = recordIn.ServiceType,
				FeeType = recordIn.FeeType,
				Description = recordIn.Description,
				BasePrice = recordIn.BasePrice,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

			return recordOut;
		}

		internal static List<DTO.Service> Map(List<Service> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Service> listOut = new List<DTO.Service>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal static List<Service> Map(List<DTO.Service> listIn)
		{
			if (listIn == null)
				return null;

			List<Service> listOut = new List<Service>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal void CopyUpdatedFields(DTO.Service recordIn, ref Service currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.ServiceType = recordIn.ServiceType;
			currentRecord.FeeType = recordIn.FeeType;
			currentRecord.Description = recordIn.Description;
			currentRecord.BasePrice = recordIn.BasePrice;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
