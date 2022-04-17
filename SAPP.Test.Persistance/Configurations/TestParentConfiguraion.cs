using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAPP.Gateway.Domain.Entities.Test;

namespace SAPP.Gateway.Persistance.Configurations
{
    internal sealed class TestParentConfiguraion : IEntityTypeConfiguration<TestParent>
    {
        public void Configure(EntityTypeBuilder<TestParent> builder)
        {
            builder.ToTable(nameof(TestParent));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(10);

            builder.Property(x=>x.Description).HasMaxLength(10);
        }
    }
}
