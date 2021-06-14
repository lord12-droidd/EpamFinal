using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task DeleteByIdAsync(string guid)
        {
            UserEntity entityToDelete = await Entity.SingleOrDefaultAsync(e => e.Id == guid);

            if (entityToDelete == null)
                return;

            Entity.Remove(entityToDelete);
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
