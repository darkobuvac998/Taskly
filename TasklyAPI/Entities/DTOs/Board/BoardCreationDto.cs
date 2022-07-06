using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Board
{
    public class BoardCreationDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public bool? Visible { get; set; }
        public bool? Pinned { get; set; }

    }
}
