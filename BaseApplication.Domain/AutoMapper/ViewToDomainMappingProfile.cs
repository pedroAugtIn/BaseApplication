using AutoMapper;
using BaseApplication.Domain.DTOs.Entries;
using BaseApplication.Domain.Models;

namespace BaseApplication.Domain.AutoMapper;

public class ViewToDomainMappingProfile : Profile
{
    public ViewToDomainMappingProfile()
    {
        CreateMap<UserEntry, User>();
    }
}