using Hospital.Core.Enums;

namespace Hospital.Web.Contracts
{
    public record CreatePatientContract(string FirstName,
        string FamilyName,
        string Patronymic,
        string Address,
        GenderEnum Sex,
        DateOnly BirthDate,
        int AreaId);
}
