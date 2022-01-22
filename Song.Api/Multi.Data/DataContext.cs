using Microsoft.EntityFrameworkCore;
using Multi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Music> Musics { get; set; }
    }
}
