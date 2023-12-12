using Challenge.Ibge.Blazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Ibge.Blazor.Infra.EntiitesMap
{
    public class LocalityMap : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.ToTable("LocalityIBGE");

            builder.HasKey(property => property.Id);
            builder.Property(property => property.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("BIGINT");

            builder.Property(property => property.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.Property(property => property.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(5);

            builder.Property(property => property.DateCreate)
                .IsRequired()
                .HasColumnName("DateCreate")
                .HasColumnType("DateTime2")
                .HasDefaultValueSql("GETDATE()"); 

        }
    }
}
