using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Adapter.Data_Formats
{
    public class XML
    {
        private string _data;

        public XML(int num)
        {
            _data = $"XML data {num}";
        }

        public override string ToString()
        {
            return _data;
        }
    }
}
