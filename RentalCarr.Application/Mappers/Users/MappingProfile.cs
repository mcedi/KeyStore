using AutoMapper;
using KeyStore.Application.Common.Dto;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Domain.Entities;



namespace KeyStore.Application.Mappers.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
        CreateMap<ApplicationUser, UserInformationDto>().ConstructUsing(x => GetUserDetails(x));
        
        
        CreateMap<IEnumerable<ApplicationUser>, UserListDto>()
            .ConstructUsing(x => GetUserList(x));
        
    }

    private static UserInformationDto GetUserDetails(ApplicationUser user)
    {
        return new UserInformationDto
        (
            user.FirstName,
            user.LastName,
            user.Email,
            user.NormalizedEmail,
            user.UserName,
            user.NormalizedUserName,
            user.Keys.Select(l => l.Name),
            user.Roles
        );
    }


    private static UserListDto GetUserList(IEnumerable<ApplicationUser> users)
    {
        var userList = users.Select(GetUserDetails).ToList();
        return new UserListDto(userList);
    }

    
}