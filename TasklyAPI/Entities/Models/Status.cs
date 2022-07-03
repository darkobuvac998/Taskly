using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Status")]
    public partial class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Color { get; set; }

        [InverseProperty(nameof(Task.Status))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
