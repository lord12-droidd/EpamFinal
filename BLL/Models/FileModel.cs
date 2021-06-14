﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public bool IsPrivate { get; set; }
        public string UploaderUsername { get; set; }
        public IFormFile FileContent { get; set; }

    }
}
