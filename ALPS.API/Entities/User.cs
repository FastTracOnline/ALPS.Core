using System;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class User : IVersionedEntity
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte Roles { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
        
        // Navigation properties
        public long? SubscriberId { get; set; }
        //public virtual Subscriber Subscriber { get; set; }
    }
}