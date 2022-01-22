using Multi.Api.DTOs.MusicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.DTOs.AlbumDtos
{
    public class AlbumListDto
    {
        public List<AlbumListItemDto> Items { get; set; }
        public int TotalPage { get; set; }
    }
}
