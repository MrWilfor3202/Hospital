using Hospital.Core.Enums;

namespace Hospital.Web.Contracts
{
    public record PatientResponse(int id,
        string FirstName,
        string FamilyName,
        string Patronymic,
        string Address,
        GenderEnum Gender,
        DateOnly BirthDate,
        int AreaId);
}
