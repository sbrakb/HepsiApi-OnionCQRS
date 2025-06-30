using System.Linq.Expressions;
using HepsiApi.Application.Interfaces.Repositories;
using HepsiApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HepsiApi.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
  private readonly DbContext _dbContext;
  public ReadRepository(DbContext dbContext)
  {
    _dbContext = dbContext;
  }

  private DbSet<T> Table { get => _dbContext.Set<T>(); }

  public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expPredicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
  {
    IQueryable<T> queryable = Table;
    if (!enableTracking) queryable = queryable.AsNoTracking();
    if (include is not null) queryable = include(queryable);
    if (expPredicate is not null) queryable = queryable.Where(expPredicate);
    if (orderBy is not null)
      return await orderBy(queryable).ToListAsync();

    return await queryable.ToListAsync();
  }

  public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? expPredicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
  {
    IQueryable<T> queryable = Table;
    if (!enableTracking) queryable = queryable.AsNoTracking();
    if (include is not null) queryable = include(queryable);
    if (expPredicate is not null) queryable = queryable.Where(expPredicate);
    if (orderBy is not null)
      return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

    return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
  }

  public async Task<T> GetAsync(Expression<Func<T, bool>> expPredicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
  {
    IQueryable<T> queryable = Table;
    if (!enableTracking) queryable = queryable.AsNoTracking();
    if (include is not null) queryable = include(queryable);

    // queryable = queryable.Where(predicate);

    return await queryable.FirstOrDefaultAsync(expPredicate);
  }

  public async Task<int> CountAsync(Expression<Func<T, bool>>? expPredicate = null)
  {
    Table.AsNoTracking();
    if (expPredicate is not null) Table.Where(expPredicate);

    return await Table.CountAsync();
  }

  public IQueryable<T> Find(Expression<Func<T, bool>> expPredicate, bool enableTracking = false)
  {
    if (!enableTracking) Table.AsNoTracking();

    return Table.Where(expPredicate);
  }

}


