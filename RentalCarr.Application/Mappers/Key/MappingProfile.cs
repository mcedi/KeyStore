using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.Key;
using KeyStore.Domain.Entities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace KeyStore.Application.Mappers.Key;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateKeyDto, KeyStore.Domain.Entities.Key>().ReverseMap();
        CreateMap<UpdateKeyDto, KeyStore.Domain.Entities.Key>().ReverseMap();
        CreateMap<KeyStore.Domain.Entities.Key, Task<KeyInformationDto>>()
            .ConstructUsing(x => GetKeyDetails(x));

        CreateMap<IEnumerable<Domain.Entities.Key>, KeyListDto>()
            .ConstructUsing(l => GetKeyList(l));
        
    }

    private static async Task<KeyInformationDto> GetKeyDetails(Domain.Entities.Key key)
    {
        return new KeyInformationDto
        (
            key.Name,
            key.Img,
            key.Description,
            (await key.KeyVendor.ToEntityAsync())!.Name,
            (await key.KeyCategory.ToEntityAsync())!.Name,
            (await key.KeyType.ToEntityAsync())!.Name,
            key.Owner.Email,
            key.IsSold,
            key.IsBought,
            key.Price,
            key.StartDate.Date,
            key.EndDate.Date
        );

        
    }

    private static KeyListDto GetKeyList(IEnumerable<Domain.Entities.Key> keys)
    {
        var keysList = keys.Select(x => GetKeyDetails(x).Result).ToList();
        return new KeyListDto(keysList);
    }

    
}