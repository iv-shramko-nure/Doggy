using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Common.Constants;

namespace Domain.Models
{
    public class Shelter
    {
        [Key]
        public Guid ShelterId { get; set; }

        [Required]
        [MinLength(ValidationConstant.NameMinLength)]
        [MaxLength(ValidationConstant.NameMaxLength)]
        public string ShelterName { get; set; }

        [MinLength(ValidationConstant.LinkMinLength)]
        [MaxLength(ValidationConstant.LinkMaxLength)]
        public string WebsiteURL { get; set; }

        public string CardNumber { get; set; }

        public byte[] ProfileImage { get; set; }

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        #region Relations

        [JsonIgnore]
        public List<Pet> Pets { get; set; }

        #endregion
    }
}
