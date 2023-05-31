using Domain.Enums;
using System;

namespace BLL.Models.Models.Pet
{
    public class PetListItemDTO
    {
        public Guid PetId { get; set; }

        public byte[] Image { get; set; }

        public PetTypeEnum PetType { get; set; }

        public string PetName { get; set; }

        public string ShelterName { get; set; }
    }
}
