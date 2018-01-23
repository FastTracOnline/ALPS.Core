using ALPS.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALPS.API.Controllers
{
    public class LocationsController : ApiBaseController
    {
        private ALPSContext context;

        public LocationsController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Locations")]
        // GET: api/Locations
        [HttpGet]
        public IEnumerable<DTO.LocationList> GetLocations()
        {
            IQueryable<Location> recordList = context.Locations;

            return recordList.Select(p => new DTO.LocationList
            {
                Id = p.Id,
                Description = p.Description,
                Address = p.Address,
                City = p.City,
                State = p.State,
                Zip = p.Zip
            });
        }

        //[ResourceAuthorize("List", "Locations")]
        // GET: api/Locations
        [Route("api/subscribers/{id:long}/locations")]
        [HttpGet]
        public IEnumerable<DTO.LocationList> GetLocationsForSubscriber(long id)
        {
            IQueryable<Location> recordList = context.Locations.Where(p=> p.SubscriberId == id);

            return recordList.Select(p => new DTO.LocationList
            {
                Id = p.Id,
                Description = p.Description,
                Address = p.Address,
                City = p.City,
                State = p.State,
                Zip = p.Zip
            });
        }

        //[ResourceAuthorize("Read", "Locations")]
        [HttpGet("{id}")]
        public ActionResult GetLocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = context.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(Map(location));
        }

        //[ResourceAuthorize("Update", "Locations")]
        [HttpPut("{id}")]
        public ActionResult PutLocation([FromRoute] long id, [FromBody] DTO.Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.Id)
            {
                return BadRequest();
            }

            if (!LocationExists(id))
            {
                return NotFound();
            }

            Location currentRecord = context.Locations.Find(id);
            
            if (currentRecord == null)
            {
                return NotFound();
            }

            currentRecord.Description = location.Description;
            currentRecord.Address = location.Address;
            currentRecord.City = location.City;
            currentRecord.State = location.State;
            currentRecord.Zip = location.Zip;
            currentRecord.Updated = DateTime.UtcNow;

            context.Locations.Update(currentRecord);

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

        //[ResourceAuthorize("Create", "Locations")]
        [HttpPost]
        public ActionResult PostLocation([FromBody] DTO.Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            location.Active = true;
            location.Created = DateTime.UtcNow;
            context.Locations.Add(Map(location));
            context.SaveChanges();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        //[ResourceAuthorize("Delete", "Locations")]
        [HttpDelete("{id}")]
        public ActionResult DeleteLocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentRecord = context.Locations.Find(id);
            if (currentRecord == null)
            {
                return NotFound();
            }

            currentRecord.Active = false;
            currentRecord.Updated = DateTime.UtcNow;
            context.Locations.Update(currentRecord);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(currentRecord);
        }

        private bool LocationExists(long id)
        {
            return (context.Locations.Find(id) != null);
        }

        internal static DTO.Location Map(Location location)
        {
            if (location == null)
                return null;

            var result = new DTO.Location
            {
                Id = location.Id,
                Description = location.Description,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zip = location.Zip,
                Notes = location.Notes,
                Active = location.Active,
                Created = location.Created,
                Updated = location.Updated,
                Version = location.Version
            };

            return result;
        }

        internal static Location Map(DTO.Location location)
        {
            if (location == null)
                return null;

            var result = new Location
            {
                Id = location.Id,
                Description = location.Description,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zip = location.Zip,
                Notes = location.Notes,
                Active = location.Active,
                Created = location.Created,
                Updated = location.Updated,
                Version = location.Version
            };

            return result;
        }

        internal static Location PatchUp(Location oldRecord, Location newRecord)
        {
            if (oldRecord == null || newRecord == null)
                return oldRecord;

            //oldRecord.? = newRecord.?;

            oldRecord.Notes = newRecord.Notes;
            oldRecord.Active = newRecord.Active;
            oldRecord.Created = (newRecord.Created == DateTime.MinValue) ? DateTime.UtcNow : newRecord.Created;
            oldRecord.Updated = (newRecord.Updated == DateTime.MinValue) ? DateTime.UtcNow : newRecord.Updated;

            return oldRecord;
        }
    }
}
