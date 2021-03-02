using Design_Patterns.Patterns.Adapter;
using Design_Patterns.Patterns.Adapter.Data_Formats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            var booksAnalyzer = new BooksAnalyzer();
            var adapter = new Adapter(booksAnalyzer);
            List<XML> xmlBooks = library.GetBooksXML();

            xmlBooks.ForEach(b => Console.WriteLine(b));
            XML oldestBook = adapter.GetOldestBook(xmlBooks);
            Console.WriteLine(oldestBook);

        }
    }
}
