using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data.Configurations;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasKey(d => d.Name);
        builder.Property(d => d.Name).HasMaxLength(50).IsRequired().HasColumnName("name");
        builder.Property(d => d.Color).HasMaxLength(50).IsRequired().HasColumnName("color");
        builder.Property(d => d.Tail_length).IsRequired().HasColumnName("tail_length");
        builder.Property(d => d.Weight).IsRequired().HasColumnName("weight");
    }
}
