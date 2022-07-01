using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4
{
    //Namespace – дефолтный ХМЛ нэймспейс – указывать обязательно
    //Description – описание веб-сервиса, отображаемое в браузере
    [WebService(Namespace = "http://kao/", Description = "Lab4")]

    //означает, что веб-сервис проверяется на соответствие спецификации WSI Basic Profile 1.1.
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(MessageName = "add", Description = "ASMX Add(int, int)")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "concat", Description = "ASMX Concat(string, double)")]
        public string Concat(string s, double d)
        {
            return s + d.ToString();
        }

        [WebMethod(MessageName = "sum", Description = "ASMX Sum(A, A)")]
        public A Sum(A a1, A a2)
        {
            using (var reader = new StreamReader(Context.Request.InputStream))
            {
                var body = reader.ReadToEnd();
            }

            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "addS", Description = "ASMX AddS(int, int)")]
        public String AddS(int x, int y)
        {
            return JsonConvert.SerializeObject(x + y);
        }
    }
}
