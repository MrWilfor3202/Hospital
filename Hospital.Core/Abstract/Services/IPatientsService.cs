using Hospital.Core.Models.Entities;
using System.Linq.Expressions;

namespace Hospital.Core.Abstract.Services
{
    public interface IPatientsService
    {
        Task<PatientEntity> CreatePatientAsync(PatientEntity patientEntity, CancellationToken token);

        Task<PatientEntity> DeletePatientByIdAsync(int id, CancellationToken token);

        Task<IEnumerable<PatientEntity>> GetAllPatientsAsync(CancellationToken token);

       Task<IEnumerable<PatientEntity>> GetAndSortPatientsByCriteriaAsync<V>(Expression<Func<PatientEntity, V>> sortingExpression,
            CancellationToken token);

        Task<PatientEntity> GetPatientByIdAsync(int id, CancellationToken token);

        Task<PatientEntity> UpdatePatientAsync(PatientEntity pathientEntity, CancellationToken token);
    }
}
