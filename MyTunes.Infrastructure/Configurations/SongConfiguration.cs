using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTunes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Infrastructure.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Rating).IsRequired();

            builder.Property(x => x.Artist).IsRequired();
        }
    }
}
