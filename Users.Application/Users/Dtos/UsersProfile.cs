using Users.Domain.Entities;
using AutoMapper;

namespace Users.Application.Users.Dtos
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
