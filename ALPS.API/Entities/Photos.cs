﻿using System;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class Photo : IVersionedEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
    }
}