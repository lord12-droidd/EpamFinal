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
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected UserManager<UserEntity> _userManager;
        protected DbSet<T> Entity { get; set; }
        public Repository(AppDbContext context)
        {
            _context = context;
            Entity = _context.Set<T>();
        }
        public Repository(AppDbContext context, UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
            _context = context;
            Entity = _context.Set<T>();
        }



        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }


        public IQueryable<T> FindAll()
        {
            return Entity.AsQueryable();
        }
    }
}
