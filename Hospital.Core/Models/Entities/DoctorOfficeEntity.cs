using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.Entities
{
    public class DoctorOfficeEntity : BaseEntity
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        public virtual List<DoctorEntity> Doctors { get; set; }
    }
}
