using HepsiApi.Domain.Common;

namespace HepsiApi.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
  Task AddAsync(T entity);
  Task AddRangeAsync(ICollection<T> entities);
  Task<T> UpdateAsync(T entity);
  Task HardDeleteAsync(T entity);
  Task HardDeleteRangeAsync(IList<T> entities);
}