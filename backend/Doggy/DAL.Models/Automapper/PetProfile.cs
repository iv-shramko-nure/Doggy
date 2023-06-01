using AutoMapper;
using Domain.Models;

namespace DAL.Models.Automapper
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, Pet>();    
        }
    }
}
