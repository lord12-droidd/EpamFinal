using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsersToFilesRepository
    {
        public Task<UserFile> AddRelation(UserEntity user, FileEntity file);
    }
}
