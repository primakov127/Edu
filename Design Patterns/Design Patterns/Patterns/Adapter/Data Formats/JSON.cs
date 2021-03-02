using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Adapter.Data_Formats
{
    public class JSON
    {
        private string _data;

        public JSON(int num)
        {
            _data = $"JSON data {num}";
        }

        public override string ToString()
        {
            return _data;
        }
    }
}
