using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Common.Constants;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(ValidationConstant.EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstant.NameMinLength)]
        [MaxLength(ValidationConstant.NameMaxLength)]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public int LocationId { get; set; }

        #region Relations

        [JsonIgnore]
        public List<Pet> Pets { get; set; }

        [JsonIgnore]
        public List<Pet> PatronizedPets { get; set; }

        [JsonIgnore]
        public List<Like> Likes { get; set; }

        [JsonIgnore]
        public Location Location { get; set; }

        #endregion
    }
}
