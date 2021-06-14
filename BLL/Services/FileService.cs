using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _directoryPath = @"C:\Users\USER\source\repos\EpamFinal\DAL\Files";
        public FileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FileModel> AddAsync(FileModel model, string userName)
        {
            var serchedUser = await _unitOfWork.UserRepository.GetByUserNameAsync(userName);
            var res = await _unitOfWork.FileRepository.AddAsync(_mapper.Map<FileEntity>(model), serchedUser);
            CreateFileInStorage(model, model.Path);
            return _mapper.Map<FileModel>(res);
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileModel> GetAll()
        {
            var files = _unitOfWork.FileRepository.FindAll();
            var mappedFiles = _mapper.Map<IEnumerable<FileEntity>, IEnumerable<FileModel>>(files);
            return mappedFiles;
        }

        public IEnumerable<FileModel> GetAllPublicFiles()
        {
            return _mapper.Map<IEnumerable<FileEntity>, IEnumerable<FileModel>>(_unitOfWork.FileRepository.FindAll().Where(file => file.IsPrivate == false));
        }

        public IEnumerable<FileModel> GetAllUserFiles(string userName)
        {
            return _mapper.Map<IEnumerable<FileEntity>, IEnumerable<FileModel>>(_unitOfWork.FileRepository.GetAllUserFiles(userName));
        }
        public async Task<FileModel> GetByFilePath(string filePath)
        {
            return  _mapper.Map<FileModel>(await _unitOfWork.FileRepository.GetByFilePath(filePath));
        }

        public async Task<MemoryStream> GetFileFromStorage(string filePath)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }

        public Task<FileModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FileModel model)
        {
            throw new NotImplementedException();
        }
        private async void CreateFileInStorage(FileModel fileModel, string filePath)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            if (fileModel.FileContent.Length > 0)
            {

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await fileModel.FileContent.CopyToAsync(fileStream);
            }
        }
    }
}
