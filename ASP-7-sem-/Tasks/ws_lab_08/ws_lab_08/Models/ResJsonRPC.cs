namespace ws_lab_08.Models
{
    public class ResJsonRPC {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public int? Result { get; set; }
    }
}