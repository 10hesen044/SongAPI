using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.DTOs.MusicDtos
{
    public class MusicListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumsCount { get; set; }
    }
}
