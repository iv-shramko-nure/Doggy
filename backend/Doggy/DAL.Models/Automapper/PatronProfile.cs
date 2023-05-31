using AutoMapper;
using DAL.Models.Models;
using Domain.Models;

namespace DAL.Models.Automapper
{
    public class PatronProfile : Profile
    {
        public PatronProfile()
        {
            CreateMap<PatronDataModel, Patron>()
                .ReverseMap();
        }
    }
}
