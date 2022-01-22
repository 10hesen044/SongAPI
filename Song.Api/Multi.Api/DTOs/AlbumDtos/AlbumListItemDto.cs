using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.DTOs.AlbumDtos
{
    public class AlbumListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MusicsCount { get; set; }
    }
}
