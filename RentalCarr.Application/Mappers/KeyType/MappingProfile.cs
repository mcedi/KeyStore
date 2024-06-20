using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.KeyType;


namespace KeyStore.Application.Mappers.KeyType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateKeyTypeDto, KeyStore.Domain.Entities.KeyType>().ReverseMap();
        CreateMap<UpdateKeyTypeDto, KeyStore.Domain.Entities.KeyType>().ReverseMap();
        CreateMap<KeyStore.Domain.Entities.KeyType, KeyTypeInformationDto>()
            .ConstructUsing(l => GetKeyTypeDetails(l));
    }

    private static KeyTypeInformationDto GetKeyTypeDetails(Domain.Entities.KeyType keyType)
    {
        return new KeyTypeInformationDto(keyType.Name, keyType.Active);
    }

}
