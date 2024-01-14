﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseRepo<T>
    {
        IQueryable<T> FindAll(List<string> includes = null);
        T Get(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
