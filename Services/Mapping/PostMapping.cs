using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Posts.Models;
using Posts.Models.ViewModels;

namespace Posts.Services.Mapping
{
    public class PostMapping
    {
        public static Post PostMapper(PostViewModel postDTO)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<PostViewModel, Post>()
                    .ForMember(dest => dest.Title, src => src.MapFrom(vm => vm.Title))
                    .ForMember(dest => dest.Content, src => src.MapFrom(vm => vm.Content))
            );
            var mapper = new Mapper(config);
            Post newPost = mapper.Map<PostViewModel, Post>(postDTO);
            return newPost;
        }
    }
}