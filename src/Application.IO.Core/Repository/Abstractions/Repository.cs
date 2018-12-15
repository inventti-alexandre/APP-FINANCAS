using Application.IO.Core.Context;
using Application.IO.Core.Domain.Source.Models;
using Application.IO.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.IO.Core.Repository.Abstractions
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        //public void Add(TEntity obj)
        //{
        //    DbSet.Add(obj);
        //}

        //public TEntity GetById(Guid id)
        //{
        //    return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return DbSet.ToList();
        //}

        //public void Update(TEntity obj)
        //{
        //    DbSet.Update(obj);
        //}

        //public void Delete(Guid id)
        //{
        //    DbSet.Remove(DbSet.Find(id));
        //}

        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return DbSet.AsNoTracking().Where(predicate);
        //}

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
