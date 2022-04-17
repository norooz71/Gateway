using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAPP.Test.Domain.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Test.Persistance.Configurations
{
    internal class TestChildConfiguration : IEntityTypeConfiguration<TestChild>
    {
        public void Configure(EntityTypeBuilder<TestChild> builder)
        {
            builder.ToTable("TestChild");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(10);

            builder.Property(x => x.Description).HasMaxLength(10);
        }
    }
}
