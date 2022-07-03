using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab14.Models
{
    public class UserConcert
    {
        [Key]
        public virtual int UserContextId { get; set; }

        [Required]
        public virtual User User { get; set; }

        [ForeignKey("User")]
        public virtual int UserId { get; set; }

        [Required]
        public virtual Concert Concert { get; set; }

        [ForeignKey("Concert")]
        public virtual int ConcertId { get; set; }
    }
}
