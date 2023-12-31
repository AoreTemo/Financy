﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces;

public interface IRepository<T> where T : class
{
    List<T> GetAllAsList();
    DbSet<T> GetAllAsTable();
    void Add(T item);
    void Update(T item);
    void Delete(int id);
    T? FindById(object id);
    T? FindById(string id);
    void SaveChanges();
}

