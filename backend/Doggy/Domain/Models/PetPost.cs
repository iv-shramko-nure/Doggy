using System;

namespace Domain.Models
{
    public class PetPost
    {
        public Guid PetPostId { get; set; }

        public int UserId { get; set; }

        public int PetId { get; set; }

        #region Relations

        public User User { get; set; }

        public Pet Pet { get; set; }

        #endregion
    }
}
