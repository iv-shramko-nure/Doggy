using Domain.Models;
using System;
using System.Collections.Generic;

namespace BLL.Models.Models.PetModels
{
    public class PetListItemDTO
    {
        public Guid PetId { get; set; }

        public string PetName { get; set; }

        public string Address { get; set; } 

        public string ShelterName { get; set; }

        public byte[] PetImage { get; set; }

        public List<Like> Likes { get; set; } 
    }
}
