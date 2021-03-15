using System;

namespace Design_Patterns.Patterns.Singleton
{
    public class Connection
    {
        private static Connection _instance;
        private static object sync = new object();

        private Connection()
        {
            Console.WriteLine("Connection is opened");
        }

        public static Connection GetInstance()
        {
            if (_instance == null)
            {
                lock (sync)
                {
                    if (_instance == null)
                        _instance = new Connection();
                }
            }
            return _instance;
        }

        public string Query(string queryString)
        {
            return $"Result of the query string: {queryString}";
        }

        public void Close()
        {
            _instance = null;
            Console.WriteLine("Connection is closed");
        }
    }
}
