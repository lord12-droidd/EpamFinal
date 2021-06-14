using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IFileRepository FileRepository { get; }

        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
