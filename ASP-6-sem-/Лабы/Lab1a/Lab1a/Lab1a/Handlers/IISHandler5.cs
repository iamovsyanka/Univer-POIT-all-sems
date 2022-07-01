using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class IISHandler5 : IHttpHandler
    {
        private string file = "XmlHttpRequest.html";
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            if (request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.WriteFile(file);               
            }
            else if (request.HttpMethod == "POST")
            {
                try
                {
                    int x = Int32.Parse(request.Params.Get("X")),
                        y = Int32.Parse(request.Params.Get("Y"));

                    response.ContentType = "text/plain";
                    response.Write(x * y);
                }
                catch (Exception ex)
                {
                    response.Write(ex.Message);
                }
            }
        }
    }
}
