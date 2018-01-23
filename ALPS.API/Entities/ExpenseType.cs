using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
	public enum ExpenseCategory
	{
		Unknown = 0,
		Commissions = 1,
		OutsideServices = 2,
	}

    public class ExpenseType : IVersionedEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
		public int ExpenseCategory { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public int Repossessor_Id { get; set; }
        [ForeignKey("Repossessor_Id")]
        public virtual Repossessor Repossessor { get; set; }
    }
}