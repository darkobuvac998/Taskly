using Entities.DTOs.TaskChecklist;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Task
{
    public class TaskUpdateDto
    {
        [Required]
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        [Required]
        public int PriorityId { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(100)]
        public string Note { get; set; }
        [StringLength(2048)]
        public string AttachmentLink { get; set; }
        public decimal? TimeAmount { get; set; }
        public virtual ICollection<TaskChecklistUpdateDto> TaskChecklists { get; set; }
    }
}
