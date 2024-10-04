namespace BaseApplication.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}