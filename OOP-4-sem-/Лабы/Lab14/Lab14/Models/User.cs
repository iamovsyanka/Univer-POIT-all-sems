using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab14.Models
{
    public class User
    {
        public User()
        {
            Concerts = new List<UserConcert>();
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string UserName { get; set; }

        [Required]
        public virtual string Password { get; set; }

        public virtual List<UserConcert> Concerts { get; set; }
    }
}
