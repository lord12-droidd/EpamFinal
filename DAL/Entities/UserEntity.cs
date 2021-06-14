using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class UserEntity : IdentityUser
    {
        public List<UserFile> Files { get; set; }
    }
}
