using AutoMapper;
using Stationery.CORE.DTOS.OrderDetailsDtos;
using Stationery.CORE.DTOS.OrdersDtos;
using Stationery.CORE.Models;

namespace Stationery.CORE.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

          
            CreateMap<Orders, OrdersResponseDto>().ReverseMap();
            CreateMap<Orders, InsertEmptyOrderDto>().ReverseMap();
            CreateMap<Orders, UpdateExistingEmptyOrderDto>().ReverseMap();
            CreateMap<OrdersDetails, OrderDetailsResponseDto>().ReverseMap();
            CreateMap<OrdersDetails, BasicOrderDetailsDto>().ReverseMap();

        }
    }
}
