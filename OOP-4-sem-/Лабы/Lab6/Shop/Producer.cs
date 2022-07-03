using System;
using System.ComponentModel.DataAnnotations;

namespace Lab5
{
    [Serializable]
    public class Producer
    {
        public string Organization { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public int Phone { get; set; }
    }
}
