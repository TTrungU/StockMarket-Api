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
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<StockPrice, StockPriceDto>().ReverseMap();
                //.ForPath(des => des.StockInfo.Id, option => option.MapFrom(src => src.Stock.Id))
                //.ForPath(des => des.StockInfo.Name, option => option.MapFrom(src => src.Stock.Symbol));
        }
        
    }
}
