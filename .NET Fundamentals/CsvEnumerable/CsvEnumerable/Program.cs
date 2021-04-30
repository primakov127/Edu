using System;

namespace CsvEnumerable
{
    class Program
    {
        static void Main()
        {
            var records = new CsvEnumerable<Record>("example.csv");
            foreach (var record in records)
            {
                Console.WriteLine($"Id: {record.Id}, Name: {record.Name}");
            }
        }
    }

    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
