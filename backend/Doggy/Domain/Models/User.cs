using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Enums;

using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(450)]
        public string IdentityUserId { get; set; }

        [Required]
        public UserRoleEnum RoleEnum { get; set; }

        //[Required]
        //public int LocationId { get; set; }

        #region Relations

        //[JsonIgnore]
        //public List<Pet> Pets { get; set; }

        //[JsonIgnore]
        //public List<Pet> PatronizedPets { get; set; }

        [JsonIgnore]
        public List<Like> Likes { get; set; }

        //[JsonIgnore]
        //public Location Location { get; set; }

        [JsonIgnore]
        public IdentityUser IdentityUser { get; set; }
        
        [JsonIgnore]
        public List<Patron> Patrons { get; set; }
        
        [JsonIgnore]
        public List<PetPost> PetPosts { get; set; }

        #endregion
    }
}
