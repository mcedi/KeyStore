using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Common.Dto;


namespace KeyStore.Application.Mappers.Order;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, KeyStore.Domain.Entities.Order>().ReverseMap();
        CreateMap<UpdateOrderDto, KeyStore.Domain.Entities.Order>().ReverseMap();
       

   
}