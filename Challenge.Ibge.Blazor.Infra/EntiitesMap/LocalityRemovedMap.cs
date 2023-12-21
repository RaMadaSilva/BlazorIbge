using Challenge.Ibge.Blazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Ibge.Blazor.Infra.EntiitesMap
{
    public class LocalityRemovedMap : IEntityTypeConfiguration<LocalityRemoved>
    {
        public void Configure(EntityTypeBuilder<LocalityRemoved> builder)
        {
            builder.ToTable("LocalityIBGERemoved");

            builder.HasKey(property => property.Id);

            builder.Property(property => property.Id)
                .IsRequired()
                .HasColumnName("Id")
                .UseIdentityAlwaysColumn();

            builder.Property(property => property.City)
                .IsRequired()
                .HasColumnName("City"); 

            builder.Property(property => property.State)
                .IsRequired()
                .HasColumnName("State");

            builder.Property(property => property.DateCreate)
                .IsRequired()
                .HasColumnName("DateCreate"); 

            builder.Property(property => property.DateRemoved)
                .IsRequired()
                .HasColumnName("DateRemoved")
                .HasDefaultValueSql("CURRENT_DATE");
        }
    }
}
