using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class IISHandler6 : IHttpHandler
    {
        private string file = "FormFor6.html";

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
                    int x = Int32.Parse(request.Form.Get("x")),
                        y = Int32.Parse(request.Form.Get("y"));

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
