namespace ws_lab_08.Models
{
    public class ReqJsonRPC {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public ISM Params { get; set; }
    }
}