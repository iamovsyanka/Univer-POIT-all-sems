using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab7a.Models
{
    public class Contact
    {
        [JsonProperty("Id")]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [JsonProperty("Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50 characters")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [JsonProperty("Phone")]
        [RegularExpression(@"\+375\d{10}", ErrorMessage = "Phone format is +375xxxxxxxxxx")]
        [Required(ErrorMessage = "Phone is required!")]
        public string Phone { get; set; }
    }
}