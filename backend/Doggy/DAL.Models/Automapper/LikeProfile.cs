using AutoMapper;
using DAL.Models.Models;
using Domain.Models;

namespace DAL.Models.Automapper
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeDataModel, Like>()
                .ReverseMap();
        }
    }
}
