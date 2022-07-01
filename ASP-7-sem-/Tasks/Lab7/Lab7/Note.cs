using Newtonsoft.Json;

namespace Lab7
{
    class Note
    {
        [JsonProperty("Subj")]
        public string Subj { get; set; }

        [JsonProperty("Note1")]
        public int Note1 { get; set; }
    }
}
