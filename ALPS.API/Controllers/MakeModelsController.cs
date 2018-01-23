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
    [Route("api/MakeModels")]
    public class MakeModelsController : ApiBaseController
    {
        private ALPSContext context;

        public MakeModelsController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "MakeModels")]
        // GET: api/MakeModels
        [HttpGet]
        public IActionResult GetMakeModels()
        {
			var subscriberId = 1;
			var queryList = context.MakeModels
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("Manufacturer,Model")
							.ToList<MakeModel>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/MakeModels/5
        [HttpGet("{id}")]
        public ActionResult GetMakeModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var MakeModel = context.MakeModels.Find(id);

            if (MakeModel == null)
            {
                return NotFound();
            }

            return Ok(Map(MakeModel));
        }

        // PUT: api/MakeModels/5
        [HttpPut("{id}")]
        public ActionResult PutMakeModel([FromRoute] long id, [FromBody] DTO.MakeModel recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!MakeModelExists(id))
            {
                return NotFound();
            }

            MakeModel currentRecord = context.MakeModels.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.MakeModels.Update(currentRecord);

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

        // POST: api/MakeModels
        [HttpPost]
        public ActionResult PostMakeModel([FromBody] DTO.MakeModel MakeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

            MakeModel.Active = true;
            MakeModel.Created = DateTime.UtcNow;
            MakeModel.SubscriberId = subscriberId;

            context.MakeModels.Add(Map(MakeModel));
            context.SaveChanges();

            return CreatedAtAction("GetMakeModel", new { id = MakeModel.Id }, MakeModel);
        }

        // DELETE: api/MakeModels/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMakeModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var MakeModel = context.MakeModels.Find(id);
            if (MakeModel == null)
            {
                return NotFound();
            }

            MakeModel.Active = false;
            MakeModel.Updated = DateTime.UtcNow;
            context.MakeModels.Update(MakeModel);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(MakeModel);
        }

        private bool MakeModelExists(long id)
        {
            return (context.MakeModels.Find(id) != null);
        }

        internal static DTO.MakeModel Map(MakeModel recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.MakeModel recordOut = new DTO.MakeModel()
            {
                Id = recordIn.Id,
				Manufacturer = recordIn.Manufacturer,
				Model = recordIn.Model,
				Notes = recordIn.Notes,
				Tips = recordIn.Tips,
				Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
                Subscriber = SubscribersController.Map(recordIn.Subscriber)
            };

            return recordOut;
        }

        internal static MakeModel Map(DTO.MakeModel recordIn)
        {
            if (recordIn == null)
                return null;

            MakeModel recordOut = new MakeModel()
            {
				Id = recordIn.Id,
				Manufacturer = recordIn.Manufacturer,
				Model = recordIn.Model,
				Notes = recordIn.Notes,
				Tips = recordIn.Tips,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

		internal List<DTO.MakeModel> Map(List<MakeModel> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.MakeModel> listOut = new List<DTO.MakeModel>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<MakeModel> Map(List<DTO.MakeModel> listIn)
		{
			if (listIn == null)
				return null;

			List<MakeModel> listOut = new List<MakeModel>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.MakeModel recordIn, ref MakeModel currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.Manufacturer = recordIn.Manufacturer;
			currentRecord.Model = recordIn.Model;
			currentRecord.Notes = recordIn.Notes;
			currentRecord.Tips = recordIn.Tips;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
