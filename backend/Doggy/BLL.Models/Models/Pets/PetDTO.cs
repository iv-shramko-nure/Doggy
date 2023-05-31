using Domain.Enums;
using System;

namespace BLL.Models.Models.Pet
{
    public class PetDTO
    {
        public Guid PetId { get; set; }

        public string PetName { get; set; }

        public byte[] Image { get; set; }

        public int PetAge { get; set; }

        public string Breed { get; set; }

        public PetTypeEnum PetType { get; set; }

        public PetStatusEnum PetStatus { get; set; }
    }
}
