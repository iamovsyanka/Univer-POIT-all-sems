using Newtonsoft.Json;
using System.Web;
using System.Web.SessionState;

namespace Lab1
{
    public class DeleteHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            ResultModel resultModel;

            if (context.Session["Lab1"] == null){
                resultModel = new ResultModel();
            } else {
                resultModel = (ResultModel)context.Session["Lab1"];

                if (resultModel.Stack.Count != 0) {
                    resultModel.Stack.Pop();
                }
            }
            context.Session["Lab1"] = resultModel;

            response.ContentType = "application/json";
            response.Write(JsonConvert.SerializeObject(resultModel));
        }
    }
}
