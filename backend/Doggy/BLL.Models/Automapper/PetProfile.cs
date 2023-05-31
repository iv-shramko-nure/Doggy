using AutoMapper;
using BLL.Models.Models.PetModels;
using Domain.Models;

namespace BLL.Models.Automapper
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<PetListItemDTO, Pet>()
                .ReverseMap();

            CreateMap<PetDTO, Pet>()
                .ReverseMap();
        }
    }
}
