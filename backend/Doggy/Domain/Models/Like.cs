using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Like
    {
        public int UserId { get; set; }

        public int PetId { get; set; }

        #region Relations

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; } 

        #endregion
    }
}
