using Users.Domain.Entities;
using AutoMapper;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.UpdateUser;

namespace Users.Application.Users.Dtos
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
