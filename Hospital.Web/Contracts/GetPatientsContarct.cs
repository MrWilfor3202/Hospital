using Hospital.Core.Enums;

namespace Hospital.Web.Contracts
{
    public record GetPatientsContarct(
        int id,
        string PatientFirstName,
        string PatientFamilyName,
        string PatientPatronymic,
        string Address,
        GenderEnum Sex,
        DateOnly BirthDate,
        int AreaNumber);
}
