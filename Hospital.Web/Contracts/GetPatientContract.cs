using Hospital.Core.Enums;

namespace Hospital.Web.Contracts
{
    public record GetPatientContract(int PatientId,
        int AreaId,
        string PatientFirstName,
        string PatientFamilyName,
        string PatientPatronymic,
        string Address,
        GenderEnum Sex,
        DateOnly BirthDate);
}
