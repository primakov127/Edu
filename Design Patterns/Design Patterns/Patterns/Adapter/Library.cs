using Design_Patterns.Patterns.Adapter.Data_Formats;
using System.Collections.Generic;

namespace Design_Patterns.Patterns.Adapter
{
    public class Library
    {
        private List<XML> _xmlBooks;

        public Library()
        {
            _xmlBooks = new List<XML>
            {
                new XML(),
                new XML(),
                new XML(),
                new XML()
            };
        }

        public List<XML> GetBooksXML()
        {
            return _xmlBooks;
        }
    }
}
