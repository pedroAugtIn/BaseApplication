using BaseApplication.Core.DomainObjects;

namespace BaseApplication.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}