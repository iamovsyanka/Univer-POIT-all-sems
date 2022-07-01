using System.Web;

namespace Lab1a.Handlers
{
    public class IISHandler2 : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            response.ContentType = "text/plain";
            response.Write($"POST-Http-KAO: ParmA = {request.Form.Get("ParmA")}, ParmB = {request.Form.Get("ParmB")}");
        }
    }
}
