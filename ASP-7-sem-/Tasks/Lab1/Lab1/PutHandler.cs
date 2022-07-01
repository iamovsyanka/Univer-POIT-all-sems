using Newtonsoft.Json;
using System.Web;
using System.Web.SessionState;

namespace Lab1
{
    public class PutHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            var param = context.Request.Params["ADD"];
            ResultModel resultModel;

            if (context.Session["Lab1"] == null) {
                resultModel = new ResultModel();
            } else {
                resultModel = (ResultModel)context.Session["Lab1"];
            }

            if (param != null) {
                resultModel.Stack.Push(int.Parse(param));
            }
            context.Session["Lab1"] = resultModel;

            response.ContentType = "application/json";
            response.Write(JsonConvert.SerializeObject(resultModel));
        }
    }
}
