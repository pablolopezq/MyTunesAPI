using Microsoft.EntityFrameworkCore;
using MyTunes.Core.Entities;
using MyTunes.Infrastructure.Configurations;
using System;

namespace MyTunes.Infrastructure
{
    public class MyTunesDbContext : DbContext
    {
        public MyTunesDbContext(DbContextOptions options) {}

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        }
    }
}
