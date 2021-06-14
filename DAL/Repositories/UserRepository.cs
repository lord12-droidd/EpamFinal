using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public class UserRepository : Repository<UserEntity>, IUserRepository
    {

        public UserRepository(AppDbContext context, UserManager<UserEntity> _userManager) : base(context, _userManager)
        {

        }

        public Task<bool> CheckPassword(UserEntity user, string password)
        {
             return _userManager.CheckPasswordAsync(user, password);
        }
        public async Task<UserEntity> AddAdminAsync(UserEntity entity, string password)
        {
            await _userManager.CreateAsync(entity, password);
            await _userManager.AddToRoleAsync(entity, "Admin");
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity> AddAsync(UserEntity entity, string password)
        {

            await _userManager.CreateAsync(entity, password);
            await _userManager.AddToRoleAsync(entity, "AppUser");
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity> DeleteByIdAsync(string guid)
        {
            var entityToDelete = Entity.Remove(await _userManager.FindByIdAsync(guid)).Entity;

            if (entityToDelete == null)
                return entityToDelete;

            _context.ApplicationUsers.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return entityToDelete;
        }

        public Task<UserEntity> GetByUserNameAsync(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public Task<UserEntity> GetByGuid(string guid)
        {
            return _userManager.FindByIdAsync(guid);
        }
        public async Task<string> GetUserRole(string userName)
        {
            return _userManager.GetRolesAsync(await GetByUserNameAsync(userName)).Result.FirstOrDefault();
        }
    }
}
