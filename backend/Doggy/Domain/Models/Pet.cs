using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Common.Constants;
using Domain.Enums;

namespace Domain.Models
{
    public class Pet
    {
        [Key]
        public Guid PetId { get; set; }

        [Required]
        [MinLength(ValidationConstant.NameMinLength)]
        [MaxLength(ValidationConstant.NameMaxLength)]
        public string PetName { get; set; }

        [Required]
        public int PetAge { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public PetTypeEnum PetType { get; set; }

        [Required]
        public PetStatusEnum PetStatus { get; set; }

        //[Required]
        //public int LocationId { get; set; }

        //public int? UserId { get; set; }

        public Guid ShelterId { get; set; }

        public string Description { get; set; }

        public decimal? Expense { get; set; }

        #region Relations

        //[JsonIgnore]
        //public Location Location { get; set; }

        //[JsonIgnore]
        //public User User { get; set; }

        [JsonIgnore]
        public Shelter Shelter { get; set; }

        [JsonIgnore]
        public Patron Patron { get; set; }
        
        [JsonIgnore]
        public PetPost PetPost { get; set; }

        [JsonIgnore]
        public List<Like> Likes { get; set; }

        #endregion
    }
}
