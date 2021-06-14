using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FileRepository : Repository<FileEntity>, IFileRepository
    {
        public FileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<FileEntity> AddAsync(FileEntity file, UserEntity user)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Files.AddAsync(file);
                    _context.SaveChanges();


                    var relationEntity = new UserFile
                    {
                        File = file,
                        FileId = file.Id,
                        User = user,
                        UserId = user.Id
                    };
                    user.Files = new List<UserFile>();
                    file.UserFiles = new List<UserFile>();
                    user.Files.Add(relationEntity);
                    file.UserFiles.Add(relationEntity);
                    await _context.UserToFiles.AddAsync(relationEntity);
                    _context.SaveChanges();

                    dbContextTransaction.Commit();
                        
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return file;
        }

        public async Task DeleteByIdAsync(int id)
        {
            FileEntity entityToDelete = await Entity.SingleOrDefaultAsync(e => e.Id == id);

            if (entityToDelete == null)
                return;

            Entity.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<FileEntity> GetAllUserFiles(string userName)
        {
            var allfiles = _context.Files.Select(file => file);
            var userFiles = allfiles.Where(file => file.UploaderUsername == userName);
            return userFiles;
        }

        public Task<FileEntity> GetByIdAsync(int id)
        {
            return Entity.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<FileEntity> GetByFilePath(string filePath)
        {
            var result = await _context.Files.FirstOrDefaultAsync(file => file.Path == filePath);
            return result;
        }

    }


}
