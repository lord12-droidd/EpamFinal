using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserEntity : IdentityUser
    {
        public List<UserFile> Files { get; set; }
    }
}
