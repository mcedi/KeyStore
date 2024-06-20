using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Application.Common.Dto.Vendor;


namespace KeyStore.Application.Mappers.Vendor;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
       CreateMap<CreateKeyVendorDto, KeyStore.Domain.Entities.KeyVendor>().ReverseMap();
        CreateMap<UpdateKeyVendorDto, KeyStore.Domain.Entities.KeyVendor>().ReverseMap();
        CreateMap<KeyStore.Domain.Entities.KeyVendor, KeyVendorInformationDto>().ConstructUsing(x => GetVendorDetails(x));
        CreateMap<IEnumerable<KeyStore.Domain.Entities.KeyVendor>, KeyVendorListDto>()
            .ConstructUsing(x => GetKeyVendorList(x));
       
    }

    private static KeyVendorInformationDto GetVendorDetails(KeyStore.Domain.Entities.KeyVendor keyVendor)
    {
        return new KeyVendorInformationDto(keyVendor.Name, keyVendor.Active);
    }


    
    private static KeyVendorListDto GetKeyVendorList(IEnumerable<Domain.Entities.KeyVendor> keyVendors)
    {
        var vendorList = keyVendors.Select(GetVendorDetails).ToList();

        return new KeyVendorListDto(vendorList);
    }

   
}
