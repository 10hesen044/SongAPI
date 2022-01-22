using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.DTOs.MusicDtos
{
    public class MusicListDto
    {
        public List<MusicListItemDto> Items { get; set; }
        public int TotalPage { get; set; }
    }
}
