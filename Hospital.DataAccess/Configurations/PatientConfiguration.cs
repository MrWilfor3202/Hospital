using Hospital.Core.Models.Entities;
using Hospital.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.Configurations
{
    internal sealed class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.ToTable(TableNames.Patients);

            builder.HasKey(t => t.Id);

            builder
               .HasOne<AreaEntity>(p => p.Area)
               .WithMany()
               .HasForeignKey(p => p.AreaId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
