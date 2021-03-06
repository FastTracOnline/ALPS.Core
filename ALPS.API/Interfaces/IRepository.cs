﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPS.API.Interfaces
{
    public interface IRepository<T> where T : class
    {
		IQueryable<T> GetAll();
		T GetById(long id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(int id);
    }
}
