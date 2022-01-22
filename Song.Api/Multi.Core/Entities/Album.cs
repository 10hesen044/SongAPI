using System;
using System.Collections.Generic;
using System.Text;

namespace Multi.Core.Entities
{
    public class Album:BaseEntity
    {
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
    }
}
