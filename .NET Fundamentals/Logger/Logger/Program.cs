using ImpromptuInterface;
using Logger.Implementation;
using System;
using System.Dynamic;
using System.Reflection;

namespace Logger
{
    class Program
    {
        static void Main()
        {
            var loggingProxy = new LoggingProxy<ISomeInterface>(new Logger());
            var loggedInstance = loggingProxy.CreateInstance(new SomeClass());

            loggedInstance.DoSmth1();
            loggedInstance.DoSmth2(5);
            loggedInstance.DoSmth3("str", 6);
        }
    }

    public interface ISomeInterface
    {
        void DoSmth1();
        void DoSmth2(int n);
        void DoSmth3(string s, int n);
    }

    public class SomeClass : ISomeInterface
    {
        public void DoSmth1()
        {
            // Do smth
        }

        public void DoSmth2(int n)
        {
            // Do smth
        }

        public void DoSmth3(string s, int n)
        {
            // Do smth
        }
    }
}
