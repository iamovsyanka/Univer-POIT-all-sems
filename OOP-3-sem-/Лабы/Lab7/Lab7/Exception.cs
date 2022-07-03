using System;

namespace Lab7
{
    public class ArgumentOutOfRangeException : Exception
    {
        public ArgumentOutOfRangeException() {}
        public ArgumentOutOfRangeException(string message) : base(message) {}
        public void GetInfo() => Console.WriteLine("ArgumentOutOfRangeException: " + Message + "\n\n" + TargetSite + "\n\n" + StackTrace);
    }
    public class IsNotIPublishingException : System.Exception
    {
        public IsNotIPublishingException() { }
        public IsNotIPublishingException(string message) : base(message) { }
        public void GetInfo() => Console.WriteLine("IsNotIPublishingException: " + Message + "\n\n" + TargetSite + "\n\n" + StackTrace);
    }
    public class ArgumentException : Exception
    {
        public ArgumentException() { }
        public ArgumentException(string message) : base(message) { }
        public void GetInfo() => Console.WriteLine("EmptyException: " + Message + "\n\n" + TargetSite + "\n\n" + StackTrace);
    }
}
