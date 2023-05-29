using System.ComponentModel.DataAnnotations;
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
    }
}
