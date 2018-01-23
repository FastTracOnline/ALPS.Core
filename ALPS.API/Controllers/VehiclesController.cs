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
    [Route("api/Vehicles")]
    public class VehiclesController : ApiBaseController
    {
        private ALPSContext context;

        public VehiclesController(ALPSContext _context)
        {
            context = _context;
        }

   //     //[ResourceAuthorize("List", "Vehicles")]
   //     // GET: api/Vehicles
   //     [HttpGet]
   //     public IActionResult GetVehicles()
   //     {
			//var subscriberId = 1;
			//var queryList = context.MakeModels
			//				.Where(c => c.SubscriberId == subscriberId)
			//				.Include("MakeModel")
			//				.ToList<Vehicle>();

			//if (queryList != null)
			//	return Ok(Map(queryList));
			//else
			//	return NoContent();

   //         //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
   //         //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
   //         //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
   //     }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public ActionResult GetVehicle([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Vehicle = context.Vehicles.Find(id);

            if (Vehicle == null)
            {
                return NotFound();
            }

            return Ok(Map(Vehicle));
        }

		//// GET: api/Vehicles/5
		//[HttpGet()]
		//[Route("api/Vehicles/{id}/VIN6")]
		//public ActionResult GetVehicleFromVIN6([FromRoute] string id)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}
		//	var subscriberId = 1;
		//	var Vehicle = context.Vehicles
		//				.Include("MakeModel")
		//				.FirstOrDefault(c => c.SubscriberId == subscriberId && c.VIN6 == id);

		//	if (Vehicle == null)
		//	{
		//		return NotFound();
		//	}

		//	return Ok(Map(Vehicle));
		//}

		// PUT: api/Vehicles/5
		[HttpPut("{id}")]
        public ActionResult PutVehicle([FromRoute] long id, [FromBody] DTO.Vehicle recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!VehicleExists(id))
            {
                return NotFound();
            }

            Vehicle currentRecord = context.Vehicles.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.Vehicles.Update(currentRecord);

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

        // POST: api/Vehicles
        [HttpPost]
        public ActionResult PostVehicle([FromBody] DTO.Vehicle Vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

            Vehicle.Active = true;
            Vehicle.Created = DateTime.UtcNow;
            Vehicle.SubscriberId = subscriberId;

            context.Vehicles.Add(Map(Vehicle));
            context.SaveChanges();

            return CreatedAtAction("GetVehicle", new { id = Vehicle.Id }, Vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Vehicle = context.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();
            }

            Vehicle.Active = false;
            Vehicle.Updated = DateTime.UtcNow;
            context.Vehicles.Update(Vehicle);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(Vehicle);
        }

        private bool VehicleExists(long id)
        {
            return (context.Vehicles.Find(id) != null);
        }

        internal static DTO.Vehicle Map(Vehicle recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Vehicle recordOut = new DTO.Vehicle()
            {
                Id = recordIn.Id,
				VIN = recordIn.VIN,
				VehicleType = recordIn.VehicleType,
				VehicleBodyType = recordIn.VehicleBodyType,
				Cylinders = recordIn.Cylinders,
				Year = recordIn.Year,
				Color = recordIn.Color,
				Tag = recordIn.Tag,
				TagState = recordIn.TagState,
				IgnitionCode = recordIn.IgnitionCode,
				TrunkCode = recordIn.TrunkCode,
				VATCode = recordIn.VATCode,
				Insured = recordIn.Insured,
				Notes = recordIn.Notes,
				Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				MakeModelId = recordIn.MakeModelId,
                MakeModel = MakeModelsController.Map(recordIn.MakeModel)
            };

            return recordOut;
        }

        internal static Vehicle Map(DTO.Vehicle recordIn)
        {
            if (recordIn == null)
                return null;

            Vehicle recordOut = new Vehicle()
            {
				Id = recordIn.Id,
				VIN = recordIn.VIN,
				VehicleType = recordIn.VehicleType,
				VehicleBodyType = recordIn.VehicleBodyType,
				Cylinders = recordIn.Cylinders,
				Year = recordIn.Year,
				Color = recordIn.Color,
				Tag = recordIn.Tag,
				TagState = recordIn.TagState,
				IgnitionCode = recordIn.IgnitionCode,
				TrunkCode = recordIn.TrunkCode,
				VATCode = recordIn.VATCode,
				Insured = recordIn.Insured,
				Notes = recordIn.Notes,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				MakeModelId = recordIn.MakeModelId,
				MakeModel = MakeModelsController.Map(recordIn.MakeModel)
			};

            return recordOut;
        }

		internal List<DTO.Vehicle> Map(List<Vehicle> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Vehicle> listOut = new List<DTO.Vehicle>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<Vehicle> Map(List<DTO.Vehicle> listIn)
		{
			if (listIn == null)
				return null;

			List<Vehicle> listOut = new List<Vehicle>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Vehicle recordIn, ref Vehicle currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.VIN = recordIn.VIN;
			currentRecord.VehicleType = recordIn.VehicleType;
			currentRecord.VehicleBodyType = recordIn.VehicleBodyType;
			currentRecord.Cylinders = recordIn.Cylinders;
			currentRecord.Year = recordIn.Year;
			currentRecord.Color = recordIn.Color;
			currentRecord.Tag = recordIn.Tag;
			currentRecord.TagState = recordIn.TagState;
			currentRecord.IgnitionCode = recordIn.IgnitionCode;
			currentRecord.TrunkCode = recordIn.TrunkCode;
			currentRecord.VATCode = recordIn.VATCode;
			currentRecord.Insured = recordIn.Insured;
			currentRecord.Notes = recordIn.Notes;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
