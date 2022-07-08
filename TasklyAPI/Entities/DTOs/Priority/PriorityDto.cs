using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Priority
{
    public class PriorityDto
    {
        public int PriorityId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
    }
}
