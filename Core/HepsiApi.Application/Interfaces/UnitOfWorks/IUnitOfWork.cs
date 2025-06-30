using HepsiApi.Application.Interfaces.Repositories;
using HepsiApi.Domain.Common;

namespace HepsiApi.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
  IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
  IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
  Task<int> SaveAsync();
  int Save();
}