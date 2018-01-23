using System;
using ALPS.Common;

namespace ALPS.DTO
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string Description { get; set; }
		public ExpenseCategory ExpenseCategory { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[] Version { get; set; }
        public int Repossessor_Id { get; set; }
    }
}