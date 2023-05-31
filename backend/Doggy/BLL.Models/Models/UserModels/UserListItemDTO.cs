using System;

namespace BLL.Models.Models.UserModels
{
    public class UserListItemDTO
    {
        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public byte[] ProfileImage { get; set; }
    }
}
