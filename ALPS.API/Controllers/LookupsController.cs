using ALPS.Repository;
using ALPS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALPS.API.Controllers
{
    public class LookupsController : ApiBaseController
    {
        public LookupsController(IUow uow)
        {
            Uow = uow;
        }

        // GET: api/lookups/makes
        [ActionName("makes")]
        public IEnumerable<Make> GetMakes()
        {
            return Uow.Makes.GetAll().OrderBy(r => r.Manufacturer);
        }

        //// GET: api/lookups/timeslots
        //[ActionName("timeslots")]
        //public IEnumerable<TimeSlot> GetTimeSlots()
        //{
        //    return Uow.TimeSlots.GetAll().OrderBy(ts => ts.Start);
        //}

        //// GET: api/lookups/tracks
        //[ActionName("tracks")]
        //public IEnumerable<Track> GetTracks()
        //{
        //    return Uow.Tracks.GetAll().OrderBy(t => t.Name);
        //}

        //// Lookups: aggregates the many little lookup lists in one payload
        //// to reduce roundtrips when the client launches.
        //// GET: api/lookups
        //[ActionName("all")]
        //public Lookups GetLookups()
        //{
        //    var lookups = new Lookups
        //    {
        //        Rooms = GetRooms().ToList(),
        //        TimeSlots = GetTimeSlots().ToList(),
        //        Tracks = GetTracks().ToList(),
        //    };
        //    return lookups;
        //}

        #region OData Future: IQueryable<T>
        //[Queryable]
        // public IQueryable<Room> Get()        
        // public IQueryable<TimeSlot> Get()
        // public IQueryable<Track> Get()
        #endregion

    }
}