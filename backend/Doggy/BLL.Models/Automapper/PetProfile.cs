using System.Collections.Generic;
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
                .ReverseMap()
                .ForMember(dst => dst.ShelterName,
                    opt => opt.MapFrom(src => src.Shelter.ShelterName));

            CreateMap<PetDTO, Pet>()
                .ReverseMap()
                .ForMember(dst => dst.PatronName,
                    opt => opt.MapFrom(src => src.Patron.User.FullName));

            //CreateMap<List<Pet>, List<PetListItemDTO>>()
            //    .ReverseMap();
        }
    }
}
