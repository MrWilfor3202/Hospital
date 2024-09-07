namespace Hospital.Web.Contracts
{
    public record GetDoctorsContract(
        int id,
        string DoctorFirstName, 
        string DoctorFamilyName,
        string DoctorPatronymic,
        string SpecializationName,
        int OfficeNumber,
        int AreaNumber);
}
