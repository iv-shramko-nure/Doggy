using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Domain.Enums;

namespace Domain.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public RegionEnum Region { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        #region Relations

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Shelter Shelter { get; set; }

        #endregion 
    }
}
