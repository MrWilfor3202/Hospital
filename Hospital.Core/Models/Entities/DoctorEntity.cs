using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.Entities
{
    public class DoctorEntity : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string Patronymic { get; set; }


        public int? AreaId { get; set; }

        public virtual AreaEntity? Area { get; set; }

        [Required]
        public int SpecializationId { get; set; }

        public virtual DoctorSpecializationEntity Specialization { get; set; }

        [Required]
        public int OfficeId { get; set; }

        public virtual DoctorOfficeEntity Office { get; set; }
    }
}
