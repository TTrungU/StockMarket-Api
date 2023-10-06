using Application.Dtos;
using Application.Model;
using AutoMapper;
using Domain.Entity;

namespace API.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserModel, User>()
                .ForMember(des => des.HashedPassword,option =>option.MapFrom(source => source.Password));
        }
        
    }
}
