namespace Lab3.Models
{
    public class StudentsQuery
    {
        public int? Limit { get; set; }
        public int Offset { get; set; }
        public SortTypes Sort { get; set; }
        public ResponseTypes Format { get; set; }
        public int? MinId { get; set; }
        public int? MaxId { get; set; }
        public string Like { get; set; }
        public string Columns { get; set; }
        public string GlobalLike { get; set; }
    }
}