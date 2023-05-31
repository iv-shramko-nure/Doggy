using AutoMapper;
using BLL.Models.Models.ShelterModels;
using Domain.Models;

namespace BLL.Models.Automapper
{
    public class ShelterProfile : Profile
    {
        public ShelterProfile()
        {
            CreateMap<ShelterListItemDTO, Shelter>()
                .ReverseMap();

            CreateMap<ShelterDTO, Shelter>()
                .ReverseMap();
        }
    }
}
