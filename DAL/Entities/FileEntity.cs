using System.Collections.Generic;

namespace DAL.Entities
{
    public class FileEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public bool IsPrivate { get; set; }
        public string UploaderUsername { get; set; }
        public List<UserFile> UserFiles { get; set; }
    }
}
