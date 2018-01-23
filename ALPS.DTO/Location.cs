using System;

namespace ALPS.DTO
{
    public class Location
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[] Version { get; set; }
        public int Repossessor_Id { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}