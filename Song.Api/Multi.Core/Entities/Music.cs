using System;
using System.Collections.Generic;
using System.Text;

namespace Multi.Core.Entities
{
    public class Music:BaseEntity
    {
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public double Range { get; set; }
        public List<Album> Albums { get; set; }
    }
}
