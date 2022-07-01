using Newtonsoft.Json;
using System.Web;
using System.Web.SessionState;

namespace Lab1
{
    public class GetHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            if (context.Session["Lab1"] == null) {
                var resultModel = new ResultModel();
                context.Session["Lab1"] = resultModel;

                response.Write(JsonConvert.SerializeObject(resultModel.Result));
            } else {
                ResultModel resultFromSession = (ResultModel)context.Session["Lab1"];
                var result = resultFromSession.Result;
                if (resultFromSession.Stack.Count != 0)
                {
                    result += resultFromSession.Stack.Peek();
                }

                response.Write(JsonConvert.SerializeObject(result));
            }          
        }     
    }
}
