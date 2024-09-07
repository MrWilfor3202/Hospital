namespace Hospital.Web.Contracts
{
    public record GetDoctorContract(int DoctorId, 
        int SpecializationId, 
        int OfficeId, 
        int? AreaId,
        string firstName,
        string familyName,
        string patronymic);
}
