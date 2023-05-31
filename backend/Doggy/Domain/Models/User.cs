using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Common.Constants;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstant.IdentityUserIdMaxLength)]
        public string IdentityUserId { get; set; }

        [Required]
        [MinLength(ValidationConstant.NameMinLength)]
        public string FullName { get; set; }

        [Required]
        public UserRoleEnum RoleEnum { get; set; }

        public byte[] ProfileImage { get; set; }

        public string Address { get; set; }

        #region Relations

        [JsonIgnore]
        public List<Like> Likes { get; set; }

        [JsonIgnore]
        public IdentityUser IdentityUser { get; set; }
        
        [JsonIgnore]
        public List<Patron> Patrons { get; set; }
        
        [JsonIgnore]
        public List<PetPost> PetPosts { get; set; }

        #endregion
    }
}
