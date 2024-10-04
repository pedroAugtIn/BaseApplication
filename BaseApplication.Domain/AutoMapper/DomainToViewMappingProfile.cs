using AutoMapper;
using BaseApplication.Domain.DTOs.Responses;
using BaseApplication.Domain.Models;

namespace BaseApplication.Domain.AutoMapper;

public class DomainToViewMappingProfile : Profile
{
    public DomainToViewMappingProfile()
    {
        CreateMap<User, UserResponse>();
    }
}