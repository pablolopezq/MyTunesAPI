using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTunes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Infrastructure.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Rating).IsRequired();

            builder.Property(x => x.Artist).IsRequired();

            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.Genre).IsRequired();
        }
    }
}
