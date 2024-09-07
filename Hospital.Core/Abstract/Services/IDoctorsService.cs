using Hospital.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Abstract.Services
{
    public interface IDoctorsService
    {
        Task<IEnumerable<DoctorEntity>> GetAllDoctorsAsync(CancellationToken token);

        Task<DoctorEntity> CreateDoctorAsync(DoctorEntity doctorEntity, CancellationToken token);

        Task<DoctorEntity> UpdateDoctorAsync(DoctorEntity doctorEntity, CancellationToken token);

        Task<DoctorEntity> DeleteDoctorByIdAsync(int id, CancellationToken token);

        Task<IEnumerable<DoctorEntity>> GetAndSortDoctorsByCriteriaAsync<V>(Expression<Func<DoctorEntity, V>> sortingExpression, CancellationToken token);

        Task<DoctorEntity> GetDoctorByIdAsync(int id, CancellationToken token);
    }
}
