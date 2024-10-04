using BaseApplication.Core.Data;
using BaseApplication.Domain.Models;

namespace BaseApplication.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> Create(User user);
    User Update(User user);
    Task<bool> Delete(int id);
    Task<IEnumerable<User>> Get();
    Task<User> GetById(int id);
}