using Hospital.Core.Models.Entities;
using Hospital.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.ToTable(TableNames.Doctors);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<DoctorSpecializationEntity>(d => d.Specialization)
                .WithMany()
                .HasForeignKey(d  => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AreaEntity>(d => d.Area)
                .WithMany()
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.Restrict);   

            builder
                .HasOne<DoctorOfficeEntity>(d => d.Office)
                .WithMany()
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
