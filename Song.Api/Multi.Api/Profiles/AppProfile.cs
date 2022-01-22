using AutoMapper;
using Multi.Api.DTOs.AlbumDtos;
using Multi.Api.DTOs.MusicDtos;
using Multi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Album, AlbumGetDto>();
            CreateMap<Album, AlbumListItemDto>()
                .ForMember(dest => dest.MusicsCount, m => m.MapFrom(src => src.Musics.Count));

            CreateMap<Music, MusicGetDto>();
            CreateMap<Music, MusicListItemDto>()
                .ForMember(dest => dest.AlbumsCount, m => m.MapFrom(src => src.Albums.Count));
        }
    }   
}
