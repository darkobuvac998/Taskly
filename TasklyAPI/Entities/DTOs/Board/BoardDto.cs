using Entities.DTOs.Task;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Board
{
    public class BoardDto
    {
        public int BoardId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int TaskNumber { get; set; }
        [Required]
        public bool? Visible { get; set; }
        public bool? Pinned { get; set; }


        public virtual ICollection<TaskDto> Tasks { get; set; }
    }
}
