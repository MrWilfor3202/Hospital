using Hospital.Core.Models.Entities;
using Hospital.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Configurations
{
    internal class DoctorOfficeConfiguration : IEntityTypeConfiguration<DoctorOfficeEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorOfficeEntity> builder)
        {
            builder.ToTable(TableNames.Offices);

            builder.HasKey(x => x.Id);
        }
    }
}
