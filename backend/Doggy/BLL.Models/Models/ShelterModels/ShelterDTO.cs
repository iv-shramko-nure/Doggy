using BLL.Models.Models.PetModels;
using System;
using System.Collections.Generic;

namespace BLL.Models.Models.ShelterModels
{
    public class ShelterDTO
    {
        public Guid? ShelterId { get; set; }

        public string ShelterName { get; set; }

        public string WebsiteURL { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime OpeningTime { get; set; }   

        public DateTime ClosingTime { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public byte[] ProfileImage { get; set; }

        public List<PetListItemDTO> Pets { get; set; }
    }
}
