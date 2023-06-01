using BLL.Models.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BLL.Models.Models.UserModels
{
    public class UserDTO
    {
        public Guid? UserId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public byte[] ProfileImage { get; set; }

        public string IdentityUserId { get; set; }

        public List<PetListItemDTO> Pets { get; set; }
    }
}
