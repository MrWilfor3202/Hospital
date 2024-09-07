namespace Hospital.Web.Contracts
{
    public record CreateDoctorContract(string FirstName,
        string FamilyName,
        string Patronymic,
        int OfficeId,
        int SpecializationId,
        int? AreaId);
}
