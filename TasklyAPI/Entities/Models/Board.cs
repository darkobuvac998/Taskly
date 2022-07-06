using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Board")]
    public partial class Board
    {
        [Key]
        public int BoardId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Description { get; set; }
        public int TaskNumber { get; set; }
        [Required]
        public bool? Visible { get; set; }
        public bool? Pinned { get; set; }

        [InverseProperty(nameof(Task.Board))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
