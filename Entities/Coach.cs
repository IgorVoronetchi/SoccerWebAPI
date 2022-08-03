using System.ComponentModel.DataAnnotations;

namespace SoccerWebAPI.Entities
{
    public class Coach
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        public int Wage { get; set; }
        public bool? Deleted { get; set; }
    }

}
