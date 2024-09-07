namespace Hospital.Web.Contracts
{
    public record DoctorResponse(int Id,
        string FirstName,
        string FamilyName,
        string Patronymic,
        int SpecializationId,
        int OfficeId,
        int? AreaId);
}
