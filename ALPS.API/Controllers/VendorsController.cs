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
    [Route("api/Vendors")]
    public class VendorsController : ApiBaseController
    {
        private ALPSContext context;

        public VendorsController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Vendors")]
        // GET: api/Vendors
        [HttpGet]
        public IActionResult GetVendors()
        {
			var subscriberId = 1;
			var queryList = context.Vendors
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("Name")
							.ToList<Vendor>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public ActionResult GetVendor([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Vendor = context.Vendors.Find(id);

            if (Vendor == null)
            {
                return NotFound();
            }

            return Ok(Map(Vendor));
        }

        // PUT: api/Vendors/5
        [HttpPut("{id}")]
        public ActionResult PutVendor([FromRoute] long id, [FromBody] DTO.Vendor recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!VendorExists(id))
            {
                return NotFound();
            }

            Vendor currentRecord = context.Vendors.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.Vendors.Update(currentRecord);

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

        // POST: api/Vendors
        [HttpPost]
        public ActionResult PostVendor([FromBody] DTO.Vendor Vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

			Vendor.Active = true;
			Vendor.Created = DateTime.UtcNow;
            Vendor.SubscriberId = subscriberId;

            context.Vendors.Add(Map(Vendor));
            context.SaveChanges();

            return CreatedAtAction("GetVendor", new { id = Vendor.Id }, Vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public ActionResult DeleteVendor([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Vendor = context.Vendors.Find(id);
            if (Vendor == null)
            {
                return NotFound();
            }

            context.Vendors.Remove(Vendor);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(Vendor);
        }

        private bool VendorExists(long id)
        {
            return (context.Vendors.Find(id) != null);
        }

        internal static DTO.Vendor Map(Vendor recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Vendor recordOut = new DTO.Vendor()
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
				VendorType = recordIn.VendorType,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

        internal static Vendor Map(DTO.Vendor recordIn)
        {
            if (recordIn == null)
                return null;

            Vendor recordOut = new Vendor()
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
				VendorType = recordIn.VendorType,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

		internal List<DTO.Vendor> Map(List<Vendor> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Vendor> listOut = new List<DTO.Vendor>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<Vendor> Map(List<DTO.Vendor> listIn)
		{
			if (listIn == null)
				return null;

			List<Vendor> listOut = new List<Vendor>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Vendor recordIn, ref Vendor currentRecord)
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

			currentRecord.VendorType = recordIn.VendorType;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
