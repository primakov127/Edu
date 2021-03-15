using Design_Patterns.Patterns.Adapter.Data_Formats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Design_Patterns.Patterns.Adapter
{
    public class BooksAnalyzer
    {
        public JSON GetOldestBook(List<JSON> booksList)
        {
            return booksList.Last();
        }
    }
}
