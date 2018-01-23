using System;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
	public enum PropertyStatus
	{
		None = 0,
		PlacedInStorage = 1,
		ReceivedByOwner = 2,
		Destroyed = 3,
	}

	public class PersonalProperty : IVersionedEntity
    {
        public long Id { get; set; }
        public string GloveBox { get; set; }
        public string Interior { get; set; }
        public string Trunk { get; set; }
        public string Disposition { get; set; }
        public int? TakenBy { get; set; }              // FK to Agent
        public DateTime DueDate { get; set; }
        public int ReleaseType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal FeeCharged { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public Order Order { get; set; }
    }
}