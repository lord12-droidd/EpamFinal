using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByGuid(string guid);
        Task<UserEntity> AddAsync(UserEntity entity, string password);
        Task<UserEntity> AddAdminAsync(UserEntity entity, string password);
        Task<UserEntity> GetByUserNameAsync(string userName);
        Task DeleteByIdAsync(string guid);
        Task<bool> CheckPassword(UserEntity user, string password);
        Task<string> GetUserRole(string userName);
    }
}
