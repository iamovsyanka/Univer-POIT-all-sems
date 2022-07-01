using Lab7;
using System;
using System.ServiceModel.Web;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8000/Lab7/Feed1");
            var svcHost = new WebServiceHost(typeof(Feed1), baseAddress);
            svcHost.Open();
            Console.WriteLine("Host Open");
            string s = Console.ReadLine();
        }
    }
}
