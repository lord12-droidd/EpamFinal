using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IFileRepository FileRepository { get; }

        IUserRepository UserRepository { get; }
        IUsersToFilesRepository UsersToFilesRepository { get; }
        Task<int> SaveAsync();
    }
}
