using System;

namespace Domain.Models
{
    public class PetPost
    {
        public Guid PetPostId { get; set; }

        public Guid UserId { get; set; }

        public Guid PetId { get; set; }

        #region Relations

        public User User { get; set; }

        public Pet Pet { get; set; }

        #endregion
    }
}
