using System;

namespace BLL.Models.Models.UserModels
{
    public class UserRegisterDTO
    {
        public Guid? UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }

        public byte[] ProfileImage { get; set; }
    }
}
