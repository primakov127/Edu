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
            var adapter = new Adapter(booksAnalyzer, library);
            XML oldestBook = adapter.GetOldestBook();
        }
    }
}
