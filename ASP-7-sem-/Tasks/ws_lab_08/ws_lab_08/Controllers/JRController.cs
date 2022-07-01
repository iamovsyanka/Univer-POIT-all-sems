using System.Web;
using System.Web.Http;
using ws_lab_08.Models;

namespace ws_lab_08.Controllers
{
    public class RAAController : ApiController
    {
        private static bool MethodsIgnore = false;

        [HttpPost]
        public object[] Multi([FromBody] ReqJsonRPC[] body) {
            int length = body.Length;
            object[] result = new object[length];

            for (int i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return result;
        }

        private object Single(ReqJsonRPC body)
        {
            if (MethodsIgnore)
                return getError(body.Id, body.Jsonrpc, "Methods are don't available");

            string method = body.Method;
            ISM param = body.Params;
            string key = param.key;
            int value = int.Parse(string.IsNullOrEmpty(param.value) ? "0" : param.value);
            int? result = null;
 
            switch (method) {
                case "SetM": {
                        result = SetM(key, value);
                        break;
                    }
                case "GetM": {
                        result = GetM(key);
                        break;
                    }
                case "AddM": {
                        result = AddM(key, value);
                        break;
                    }
                case "SubM": {
                        result = SubM(key, value);
                        break;
                    }
                case "MulM": {
                        result = MulM(key, value);
                        break;
                    }
                case "DivM": {
                        if (value == 0)
                        {
                            return getError(body.Id, body.Jsonrpc, string.Format("Division by 0 is prohibited", body.Method));
                        }
                        result = DivM(key, value);
                        break;
                    }
                case "ErrorExit": {
                        ErrorExit();
                        break;
                    }
                default: {
                        return getError(body.Id, body.Jsonrpc, string.Format("Function {0} is not found", body.Method));
                    }
            }
            return new ResJsonRPC() {
                Id = body.Id,
                Jsonrpc = body.Jsonrpc,
                Method = body.Method,
                Result = result
            };
        }

        private ResJsonRPCError getError(string id, string jsonrpc, string message) {
            return new ResJsonRPCError() {
                Id = id,
                Jsonrpc = jsonrpc,
                Error = message
            };
        }

        private int? SetM(string k, int x) {
            HttpContext.Current.Application[k] = x;
            return GetM(k);
        }

        private int? GetM(string k) {
            object result = HttpContext.Current.Application[k];
            return result == null ? null : (int?)int.Parse(result.ToString());
        }

        private int? AddM(string k, int x) {
            int? value = GetM(k);
            HttpContext.Current.Application[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x) {
            int? value = GetM(k);
            HttpContext.Current.Application[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x) {
            int? value = GetM(k);
            HttpContext.Current.Application[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x) {
            int? value = GetM(k);
            HttpContext.Current.Application[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit() {
            HttpContext.Current.Application.Clear();
            MethodsIgnore = true;
        }
    }
}
