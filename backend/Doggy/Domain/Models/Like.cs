using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Like
    {
        [Key]
        public Guid LikeId { get; set; }

        public Guid UserId { get; set; }

        public Guid PetId { get; set; }

        #region Relations

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; } 

        #endregion
    }
}
