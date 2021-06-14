using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UsersToFilesRepository : Repository<UserFile>, IUsersToFilesRepository
    {
        public UsersToFilesRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<UserFile> AddRelation(UserEntity user, FileEntity file)
        {
            

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
            //_context.ApplicationUsers.FirstOrDefault(x => x.Id == user.Id).Files.Add(relationEntity);
            //_context.Files.FirstOrDefault(x => x.Id == file.Id).UserFiles.Add(relationEntity);
            //await _context.ApplicationUsers.AddAsync(user);
            //await _context.Files.AddAsync(file);
            //await _context.UserToFiles.AddAsync(relationEntity);
            return relationEntity;
        }
    }
}
