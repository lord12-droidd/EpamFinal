using AutoMapper;
using DAL.Entities;
using BLL.Models;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //CreateMap<FileEntity, FileModel>()
            //    .ForMember(bm => bm, opt => opt.MapFrom(file => file.Id))
            //    .ForMember(bm => bm, opt => opt.MapFrom(file => file.Link))
            //    .ForMember(bm => bm, opt => opt.MapFrom(file => file.Name))
            //    .ForMember(bm => bm, opt => opt.MapFrom(file => file.Path))
            //    .ReverseMap();

            CreateMap<FileEntity, FileModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            //CreateMap<IEnumerable<FileEntity>, IEnumerable<FileModel>>().ReverseMap();
            //CreateMap<UserEntity, UserModel>().IncludeMembers(r => r.Files).ReverseMap();
            //CreateMap<UserEntity, UserModel>()
            //    .ForMember(bm => bm, opt => opt.MapFrom(user => user.Id))
            //    .ForMember(bm => bm, opt => opt.MapFrom(user => user.Login))
            //    .ForMember(bm => bm, opt => opt.MapFrom(user => user.Password))
            //    .ForMember(bm => bm, opt => opt.MapFrom(user => user.Files.Select(file => file.Id)))
            //    .ReverseMap();

        }
    }
}
