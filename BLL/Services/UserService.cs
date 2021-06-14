using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Validation validation = new Validation();
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserModel> AddAdminAsync(UserModel model)
        {
            var res = await _unitOfWork.UserRepository.AddAdminAsync(_mapper.Map<UserEntity>(model), model.Password);
            return _mapper.Map<UserModel>(res);
        }

        public async Task<UserModel> AddAsync(UserModel model)
        {
            var res = await _unitOfWork.UserRepository.AddAsync(_mapper.Map<UserEntity>(model), model.Password);
            return _mapper.Map<UserModel>(res);
            //await _userManager.CreateAsync(_mapper.Map<UserEntity>(model), model.Password);
        }

        public bool CheckPassword(string userName, string password)
        {
            var result = _unitOfWork.UserRepository.GetByUserNameAsync(userName).Result;
            return _unitOfWork.UserRepository.CheckPassword(result, password).Result;
        }

        public bool CheckValidation(UserModel model)
        {
           return validation.Validator(GetAll(), model);
        }

        public Task DeleteByIdAsync(string modelGuid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            var users = _unitOfWork.UserRepository.FindAll();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public UserModel GetByGuid(string guid)
        {
            var result = _unitOfWork.UserRepository.GetByGuid(guid).Result;
            return _mapper.Map<UserModel>(result);
        }


        public UserModel GetByUserName(string userName)
        {
            var result = _unitOfWork.UserRepository.GetByUserNameAsync(userName).Result;
            var returnModel = _mapper.Map<UserModel>(result);
            if (returnModel == null)
            {
                return returnModel;
            }
            var role = _unitOfWork.UserRepository.GetUserRole(userName);
            returnModel.Role = role.Result;
            return returnModel;
        }

        public string GetUserGuid(UserModel user)
        {
            return _unitOfWork.UserRepository.GetByUserNameAsync(user.UserName).Result.Id;
           
        }

        public Task UpdateAsync(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
