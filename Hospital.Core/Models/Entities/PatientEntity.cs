using Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.Entities
{
    public class PatientEntity : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public GenderEnum Sex { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public int AreaId { get; set; }

        public virtual AreaEntity Area { get; set; }
    }
}
