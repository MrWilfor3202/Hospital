using Microsoft.EntityFrameworkCore;
using Hospital.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using Hospital.Core.Models.Entities;

namespace Hospital.DataAccess.Context
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext() 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<AreaEntity>().HasData(new AreaEntity[]
            {
                new AreaEntity {Id = 1, Number = 1},
                new AreaEntity {Id = 2, Number = 2},
                new AreaEntity {Id = 3, Number = 3},
                new AreaEntity {Id = 4, Number = 4},
                new AreaEntity {Id = 5, Number = 5}
            });

            modelBuilder.Entity<DoctorOfficeEntity>().HasData(new DoctorOfficeEntity[]
            {
                new DoctorOfficeEntity {Id = 1, Number = 1},
                new DoctorOfficeEntity {Id = 2, Number = 2},
                new DoctorOfficeEntity {Id = 3, Number = 3},
                new DoctorOfficeEntity {Id = 4, Number = 4},
                new DoctorOfficeEntity {Id = 5, Number = 5}
            });

            modelBuilder.Entity<DoctorSpecializationEntity>().HasData(new DoctorSpecializationEntity[]
            {
                new DoctorSpecializationEntity {Id = 1, Name = "Терапевт"},
                new DoctorSpecializationEntity {Id = 2, Name = "Психиатр"},
                new DoctorSpecializationEntity {Id = 3, Name = "Стоматолог"},
                new DoctorSpecializationEntity {Id = 4, Name = "Ортопед"},
                new DoctorSpecializationEntity {Id = 5, Name = "Офтальмолог"},
            });


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Hospital;Trusted_Connection=True;");
        }
    }
}
