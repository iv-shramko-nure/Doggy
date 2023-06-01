using AutoMapper;
using BLL.Models.Models.UserModels;
using Domain.Models;

namespace BLL.Models.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserListItemDTO, User>()
                .ReverseMap();

            CreateMap<UserDTO, User>() 
                .ReverseMap();

            CreateMap<UserDTO, UserRegisterDTO>()
                .ReverseMap();
        }
    }
}
