using Design_Patterns.Patterns.Singleton;
using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataBase())
            {
                db.Open();
                string queryResult = db.Query("SELECT * FROM USERS");
                Console.WriteLine(queryResult);
            }
        }
    }
}
