using BaseApplication.Domain.DTOs.Entries;
using BaseApplication.Domain.DTOs.Responses;

namespace BaseApplication.Domain.Interfaces.Services;

public interface IUserService
{
    Task<BaseResponse<IEnumerable<UserResponse>>> Get();
    Task<BaseResponse<UserResponse>> GetById(int id);
    Task<BaseResponse<UserResponse>> Create(UserEntry user);
    Task<BaseResponse<UserResponse>> Update(int id, UserEntry user);
    Task<BaseResponse<UserResponse>> Delete(int id);
}