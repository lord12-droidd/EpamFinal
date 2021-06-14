using BLL.Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : ICrud<UserModel>
    {
        UserModel GetByUserName(string userName);
        UserModel GetByGuid(string guid);
        Task DeleteByIdAsync(string modelGuid);
        bool CheckPassword(string userName, string password);
        string GetUserGuid(UserModel user);
        bool CheckValidation(UserModel model);
        Task<UserModel> AddAdminAsync(UserModel model);
        Task<UserModel> AddAsync(UserModel model);
    }
}
