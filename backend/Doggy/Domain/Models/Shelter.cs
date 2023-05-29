using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Common.Constants;

namespace Domain.Models
{
    public class Shelter
    {
        [Key]
        public int ShelterId { get; set; }

        [Required]
        [MinLength(ValidationConstant.NameMinLength)]
        [MaxLength(ValidationConstant.NameMaxLength)]
        public string ShelterName { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        [MinLength(ValidationConstant.EmailMinLength)]
        public string Email { get; set; }

        [MinLength(ValidationConstant.LinkMinLength)]
        [MaxLength(ValidationConstant.LinkMaxLength)]
        public string WebsiteURL { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }

        public string PhoneNumber { get; set; }

        public string CardNumber { get; set; }

        #region Relations

        [JsonIgnore]
        public Location Location { get; set; }

        [JsonIgnore]
        public List<Pet> Pets { get; set; } 

        #endregion
    }
}
