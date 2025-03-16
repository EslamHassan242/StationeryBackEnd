using AutoMapper;
using Stationery.CORE.DTOS.OrderDetailsDtos;
using Stationery.CORE.DTOS.OrdersDtos;
using Stationery.CORE.DTOS.ProductsDtos;
using Stationery.CORE.DTOS.SuppliersDtos;
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
            CreateMap<Suppliers, SuppliersResponseDto>().ReverseMap();
            CreateMap<Suppliers, InsertSupplierDto>().ReverseMap();
            CreateMap<Products, ProductsResponseDto>().ReverseMap();
            CreateMap<Products, InsertProductsDto>().ReverseMap();

        }
    }
}
