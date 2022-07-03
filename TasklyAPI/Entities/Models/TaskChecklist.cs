using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TaskChecklist")]
    public partial class TaskChecklist
    {
        [Key]
        public int TaskChecklistId { get; set; }
        public int TaskId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; }
        public bool Checked { get; set; }

        [ForeignKey(nameof(TaskId))]
        [InverseProperty("TaskChecklists")]
        public virtual Task Task { get; set; }
    }
}
