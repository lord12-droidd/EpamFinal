using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserFile
    {
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int FileId { get; set; }
        public FileEntity File { get; set; }
    }
}
