using AutoMapper;
using BaseApplication.Domain.DTOs.Entries;
using BaseApplication.Domain.DTOs.Responses;
using BaseApplication.Domain.Interfaces.Repositories;
using BaseApplication.Domain.Interfaces.Services;
using BaseApplication.Domain.Models;

namespace BaseApplication.Services.Services;

public class UserService(IUserRepository repository, IMapper mapper) : IUserService
{
    public async Task<BaseResponse<IEnumerable<UserResponse>>> Get()
    {
        var users = await repository.Get();
        var response = mapper.Map<IEnumerable<UserResponse>>(users);
        return new BaseResponse<IEnumerable<UserResponse>>(true, response);
    }

    public async Task<BaseResponse<UserResponse>> GetById(int id)
    {
        var user = await repository.GetById(id);
        return new BaseResponse<UserResponse>(true, mapper.Map<UserResponse>(user));
    }

    public async Task<BaseResponse<UserResponse>> Create(UserEntry user)
    {
        var newUser = await repository.Create(mapper.Map<User>(user));
        await repository.UnitOfWork.Commit();
        return new BaseResponse<UserResponse>(true, mapper.Map<UserResponse>(newUser),
            "Usuário cadastrado com sucesso!");
    }

    public async Task<BaseResponse<UserResponse>> Update(int id, UserEntry user)
    {
        var userDb = await repository.GetById(id);
        mapper.Map(user, userDb);
        var updatedUser = repository.Update(userDb);

        await repository.UnitOfWork.Commit();
        return new BaseResponse<UserResponse>(true, mapper.Map<UserResponse>(updatedUser),
            "Usuário atualizado com sucesso!");

    }

    public async Task<BaseResponse<UserResponse>> Delete(int id)
    {
        var userDeleted = await repository.Delete(id);
        await repository.UnitOfWork.Commit();
        return new BaseResponse<UserResponse>(userDeleted, null, "Usuário excluído com sucesso!");
    }
}