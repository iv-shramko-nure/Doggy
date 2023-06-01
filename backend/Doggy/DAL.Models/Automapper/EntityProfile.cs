using AutoMapper;
using DAL.Models.Models;
using Domain.Models;

namespace DAL.Models.Automapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            #region User

            CreateMap<User, User>();

            CreateMap<LikeDataModel, Like>()
               .ReverseMap();

            CreateMap<PatronDataModel, Patron>()
               .ReverseMap();

            #endregion

            #region Pet

            CreateMap<Pet, Pet>();

            #endregion

            #region Shelter

            CreateMap<Shelter, Shelter>();

            #endregion
        }
    }
}
