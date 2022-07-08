using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Status
{
    public class StatusDto
    {
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
    }
}
