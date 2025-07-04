using System.Linq.Expressions;
using HepsiApi.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;


namespace HepsiApi.Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
  Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expPredicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
  bool enableTracking = false);


  Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? expPredicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
  bool enableTracking = false, int currentPage = 1, int pageSize = 3);


  Task<T> GetAsync(Expression<Func<T, bool>> expPredicate,
  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
  bool enableTracking = false);

  // sorgu halini getirir
  IQueryable<T> Find(Expression<Func<T, bool>> expPredicate, bool enableTracking = false);

  Task<int> CountAsync(Expression<Func<T, bool>>? expPredicate = null);
}
