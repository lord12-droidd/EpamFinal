﻿using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<UserEntity> _userManager;

        private readonly AppDbContext _context;
        public IFileRepository FileRepository { get; }

        public IUserRepository UserRepository { get; }

        public IUsersToFilesRepository UsersToFilesRepository { get; }

        public UnitOfWork(AppDbContext context, UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
            _context = context;
            FileRepository = new FileRepository(_context);
            UserRepository = new UserRepository(_context, _userManager);
            UsersToFilesRepository = new UsersToFilesRepository(_context);
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
