using Design_Patterns.Patterns.Adapter.Data_Formats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Design_Patterns.Patterns.Adapter
{
    public class Adapter
    {
        private readonly BooksAnalyzer _booksAnalyzer;
        private readonly Library _library;

        public Adapter(BooksAnalyzer booksAnalyzer, Library library)
        {
            _booksAnalyzer = booksAnalyzer;
            _library = library;
        }

        public XML GetOldestBook()
        {
            List<XML> xmlBooksList = _library.GetBooksXML();
            List<JSON> jsonBooksList = xmlBooksList.Select(xml => new JSON()).ToList();

            JSON jsonOldestBook = _booksAnalyzer.GetOldestBook(jsonBooksList);

            XML xmlOldestBook = new XML();

            return xmlOldestBook;
        }
    }
}
