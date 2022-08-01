using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerWebAPI.Entities
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string BestPlayer { get; set; }

        [Required]
        public Guid CoachId { get; set; }

        [ForeignKey("CoachId")]
        public virtual Coach Coach { get; set; }

        public bool? Deleted { get; set; }
    }
}
