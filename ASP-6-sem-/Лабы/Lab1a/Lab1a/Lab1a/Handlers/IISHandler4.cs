using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class IISHandler4 : IHttpHandler
    {
        private string file = "FormFor4.html";

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
                    int x = Int32.Parse(request.Form.Get("X")),
                        y = Int32.Parse(request.Form.Get("Y"));

                    response.ContentType = "text/plain";
                    response.Write($"X = {x}, Y = {y}, sum = {x + y}");
                }
                catch (Exception ex)
                {
                    response.Write(ex.Message);
                }
            }

        }
    }
}
