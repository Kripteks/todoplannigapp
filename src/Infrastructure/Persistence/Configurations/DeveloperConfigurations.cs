using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DeveloperConfigurations : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(t => t.Guid);
            builder.Property(t => t.DeveloperName)
                .IsRequired()
                .HasMaxLength(100);

            
        }
    }
}
