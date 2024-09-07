namespace Hospital.Web.Contracts
{
    public record EditDoctorContract(string? FirstName,
        string? FamilyName,
        string? Patronymic,
        int? OfficeId,
        int? SpecializationId,
        int? AreaId);
}
