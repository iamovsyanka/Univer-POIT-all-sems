using System.Web;

namespace Lab1a.Handlers
{
    public class IISHandler1 : IHttpHandler
    {
        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            response.ContentType = "text/plain";
            response.Write($"GET-Http-KAO: ParmA = {request.Params.Get("ParmA")}, ParmB = {request.Params.Get("ParmB")}");
        }
    }
}
