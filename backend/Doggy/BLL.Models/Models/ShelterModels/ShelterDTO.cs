using BLL.Models.Models.PetModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace BLL.Models.Models.ShelterModels
{
    public class ShelterDTO
    {
        public Guid? ShelterId { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime OpeningHour { get; set; }   

        public DateTime ClosingHour { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public byte[] ProfileImage { get; set; }

        public List<PetListItemDTO> Pets { get; set; }
    }
}
