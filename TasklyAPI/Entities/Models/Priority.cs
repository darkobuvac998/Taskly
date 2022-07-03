using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Priority")]
    public partial class Priority
    {
        [Key]
        public int PriorityId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Color { get; set; }

        [InverseProperty(nameof(Task.Priority))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
