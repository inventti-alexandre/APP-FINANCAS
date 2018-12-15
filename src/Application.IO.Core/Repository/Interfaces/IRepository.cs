using Application.IO.Core.Domain.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.IO.Core.Repository.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        //void Add(TEntity obj);
        //TEntity GetById(Guid id);
        //IEnumerable<TEntity> GetAll();
        //void Update(TEntity obj);
        //void Delete(Guid id);
        //IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        //int SaveChanges();
    }
}
