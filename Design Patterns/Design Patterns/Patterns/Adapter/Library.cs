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
                new XML(1),
                new XML(2),
                new XML(3),
                new XML(4)
            };
        }

        public List<XML> GetBooksXML()
        {
            return _xmlBooks;
        }
    }
}
