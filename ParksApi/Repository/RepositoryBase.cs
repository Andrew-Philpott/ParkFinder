using ParksApi.Contracts;
using ParksApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ParksApi.Repository
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected ParksApiContext ParksApiContext { get; set; }

    public RepositoryBase(ParksApiContext parksApiContext)
    {
      this.ParksApiContext = parksApiContext;
    }

    public IQueryable<T> FindAll()
    {
      return this.ParksApiContext.Set<T>().AsNoTracking();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => this.ParksApiContext.Set<T>().Where(expression).AsNoTracking();
    public void Create(T entity)
    {
      this.ParksApiContext.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
      this.ParksApiContext.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
      this.ParksApiContext.Set<T>().Remove(entity);
    }
  }
}