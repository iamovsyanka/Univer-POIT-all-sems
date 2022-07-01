using Lab3.Models;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Xml.Serialization;

namespace Lab3.Controllers
{
    public class ErrorsController : ApiController
    {
        [Route("api/errors/{code}")]
        public object Get([FromUri] int code)
        {
            Error error = new Error()
            {
                Code = code
            };
            switch (code)
            {
                case 40000:
                    error.Message = "client error. item is invalid";
                    break;
                case 40004:
                    error.Message = "client error. item not found";
                    break;
                case 50000:
                    error.Message = "server error. internal exception";
                    break;
                default:
                    error.Message = "unknown error.";
                    break;
            }
            XmlSerializer res = new XmlSerializer(typeof(Error));
            XmlMediaTypeFormatter formatter = new XmlMediaTypeFormatter
            {
                UseXmlSerializer = true
            };
            formatter.SetSerializer(typeof(Error), res);
            return Content(HttpStatusCode.OK, error, formatter);
        }
    }
}