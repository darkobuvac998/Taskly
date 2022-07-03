using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Task")]
    public partial class Task
    {

        [Key]
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int BoardId { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Note { get; set; }
        [StringLength(2048)]
        [Unicode(false)]
        public string AttachmentLink { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TimeAmount { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("Tasks")]
        public virtual Board Board { get; set; }
        [ForeignKey(nameof(PriorityId))]
        [InverseProperty("Tasks")]
        public virtual Priority Priority { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("Tasks")]
        public virtual Status Status { get; set; }
        [InverseProperty(nameof(TaskChecklist.Task))]
        public virtual ICollection<TaskChecklist> TaskChecklists { get; set; }
    }
}
