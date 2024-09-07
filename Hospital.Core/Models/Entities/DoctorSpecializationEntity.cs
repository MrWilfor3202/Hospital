using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.Entities
{
    public class DoctorSpecializationEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual List<DoctorEntity> Doctors { get; set; }
    }
}
