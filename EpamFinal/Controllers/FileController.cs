using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private const string _directoryPath = @"C:\Users\USER\source\repos\EpamFinal\DAL\Files";

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(IFormFile file, [FromQuery] bool privacy, [FromQuery] string userName)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(_directoryPath, file.FileName);
                var fileInfo = new FileModel
                {
                    IsPrivate = privacy,
                    Path = filePath,
                    Name = file.FileName,
                    UploaderUsername = userName,
                    FileContent = file
                };
                await _fileService.AddAsync(fileInfo, userName);
            }
            return Ok();
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var filePath = Path.Combine(_directoryPath, file);
            if (await _fileService.GetByFilePath(filePath) == null)
            {
                return NotFound();
            }
            var fileToDownload = _fileService.GetFileFromStorage(filePath).Result;

            return File(fileToDownload, GetContentType(filePath), file);
        }

        [HttpGet]
        [Route("Files")]
        public IActionResult Files()
        {
            var userFiles = _fileService.GetAllPublicFiles();
            return Ok(userFiles.Select(file => file.Name));
        }

        [HttpGet]
        [Route("PersonalFiles")]
        public IActionResult PersonalFiles([FromQuery] string userName)
        {
            var userFiles = _fileService.GetAllUserFiles(userName);
            return Ok(userFiles.Select(file => file.Name));
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
