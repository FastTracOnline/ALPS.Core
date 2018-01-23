﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Interfaces
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        IQueryable<Subscriber> GetAll(long id);
    }
}
