using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Models.PetModels
{
    public class PetDTO
    {
        public Guid? PetId { get; set; }

        public string PetName { get; set; }

        public int PetAge { get; set; }
        
        public string Breed { get; set; }

        public PetTypeEnum PetType { get; set; }

        public PetStatusEnum PetStatus { get; set; }

        public Guid? ShelterId { get; set; }

        public Guid? UserId { get; set; }

        public List<KeyValuePair<Guid, string>> Users { get; set; }

        public List<KeyValuePair<Guid, string>> Shelters { get; set; }

        public string PatronName { get; set; }
    }
}
