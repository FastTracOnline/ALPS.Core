﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPS.DTO
{
    public class User
    {
        public string Username { get; set; }

        public long SubscriberId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
