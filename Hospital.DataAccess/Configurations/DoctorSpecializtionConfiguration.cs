using Hospital.Core.Models.Entities;
using Hospital.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.Configurations
{
    internal class DoctorSpecializtionConfiguration : IEntityTypeConfiguration<DoctorSpecializationEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecializationEntity> builder)
        {
            builder.ToTable(TableNames.Specializations);

            builder.HasKey(x => x.Id);
        }
    }
}
