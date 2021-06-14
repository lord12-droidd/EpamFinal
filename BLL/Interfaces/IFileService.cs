using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFileService : ICrud<FileModel>
    {
        Task<FileModel> GetByIdAsync(int id);
        Task DeleteByIdAsync(int modelId);
        Task<FileModel> AddAsync(FileModel file, string userName);
        IEnumerable<FileModel> GetAllUserFiles(string userName);
        IEnumerable<FileModel> GetAllPublicFiles();
    }
}
