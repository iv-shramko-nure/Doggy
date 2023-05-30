using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Role
    {
        public IdentityUser IdentityUser { get; set; }

        public UserRoleEnum RoleEnum { get; set; }
    }
}
