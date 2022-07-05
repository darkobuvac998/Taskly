using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.TaskChecklist
{
    public class TaskChecklistDto
    {
        public int TaskChecklistId { get; set; }
        public int TaskId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}
