using BaseApplication.Core.Data;
using BaseApplication.Domain.Interfaces.Repositories;
using BaseApplication.Domain.Models;
using BaseApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApplication.Infra.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<User> Create(User user)
    {
        await context.Users.AddAsync(user);
        return user;    
    }

    public User Update(User user)
    {
        context.Users.Update(user);
        return user;
    }

    public async Task<bool> Delete(int id)
    {
        context.Users.Remove(await GetById(id));
        return true;
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await context.Users
            .AsNoTracking()
            .OrderByDescending(a => a.UpdatedAt)
            .ToListAsync();    
    }

    public async Task<User> GetById(int id)
    {
        return await context.Users.AsNoTracking()
            .FirstOrDefaultAsync(acceptance => acceptance.Id == id);    }
    
    public void Dispose()
    {
        context.Dispose();
    }
}