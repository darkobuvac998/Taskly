using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.TaskChecklist
{
    public class TaskChecklistUpdateDto
    {
        public int? TaskChecklistId { get; set; }
        public int TaskId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}
