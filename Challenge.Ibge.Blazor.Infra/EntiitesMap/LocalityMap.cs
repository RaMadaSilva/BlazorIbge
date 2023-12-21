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
                .UseIdentityAlwaysColumn()
                .HasColumnName("Id"); 

            builder.Property(property => property.City)
                .IsRequired()
                .HasColumnName("City"); 

            builder.Property(property => property.State)
                .IsRequired()
                .HasColumnName("State"); 

            builder.Property(property => property.DateCreate)
                .IsRequired()
                .HasColumnName("DateCreate")
                .HasDefaultValueSql("CURRENT_DATE"); 
        }
    }
}
