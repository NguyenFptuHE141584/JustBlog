using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Web.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, PostDetailViewModel>().ReverseMap();
        }
    }
}