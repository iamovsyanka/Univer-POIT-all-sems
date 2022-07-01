using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Contact
    {
        [JsonProperty("Id")]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

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