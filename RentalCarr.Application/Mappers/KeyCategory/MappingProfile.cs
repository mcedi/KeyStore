using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.Category;


namespace KeyStore.Application.Mappers.Category;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateKeyCategoryDto, KeyStore.Domain.Entities.KeyCategory>().ReverseMap();
        CreateMap<UpdateKeyCategoryDto, KeyStore.Domain.Entities.KeyCategory>().ReverseMap();
        CreateMap<KeyStore.Domain.Entities.KeyCategory, KeyCategoryInformationDto>()
            .ConstructUsing(cat => GetKeyCategoryDetails(cat));
        
    }

    private static KeyCategoryInformationDto GetKeyCategoryDetails(Domain.Entities.KeyCategory keyCategory)
    {
        return new KeyCategoryInformationDto(keyCategory.Name, keyCategory.Active);
    }

    
}
