using System;

namespace Lab5
{
    [Serializable]
    public class Producer
    {
        public string Organization { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }
}
