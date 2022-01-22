using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.DTOs.MusicDtos
{
    public class MusicGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
