using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
