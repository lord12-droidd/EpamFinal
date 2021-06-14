using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFileRepository : IRepository<FileEntity>
    {
        Task<FileEntity> AddAsync(FileEntity file, UserEntity user);
        Task<FileEntity> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        IEnumerable<FileEntity> GetAllUserFiles(string userName);
        Task<FileEntity> GetByFilePath(string filePath);
    }
}
