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

        public Adapter(BooksAnalyzer booksAnalyzer)
        {
            _booksAnalyzer = booksAnalyzer;
        }

        public XML GetOldestBook(List<XML> booksList)
        {
            List<JSON> jsonBooksList = booksList
                .Select(xml =>
                {
                    int bookNum = Int32.Parse(xml.ToString().Last().ToString());
                    return new JSON(bookNum);
                }).ToList();

            JSON jsonOldestBook = _booksAnalyzer.GetOldestBook(jsonBooksList);

            int oldestBookNum = Int32.Parse(jsonOldestBook.ToString().Last().ToString());
            XML xmlOldestBook = new XML(oldestBookNum);

            return xmlOldestBook;
        }
    }
}
