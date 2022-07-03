using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace Lab14.Models
{
    public class Concert
    {
        [Required]
        [Key]
        public virtual int ConcertId { get; set; }

        [Required]
        public virtual string Group { get; set; }

        [Required]
        public virtual int Count { get; set; }

        [Required]
        public virtual string Zone { get; set; }

        [Required]
        public virtual DateTime When { get; set; }

        public Concert()
        {
            Concerts = new List<UserConcert>();
        }

        public Concert(string group, int count, string zone, DateTime dateTime)
        {
            Group = group;
            Count = count;
            Zone = zone;
            When = dateTime;
            Concerts = new List<UserConcert>();
        }

        public virtual List<UserConcert> Concerts { get; set; }
    }
}
