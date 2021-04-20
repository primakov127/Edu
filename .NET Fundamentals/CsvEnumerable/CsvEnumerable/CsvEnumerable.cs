using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable<T>
    {
        private readonly string _filePath;

        public CsvEnumerable(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerator<T> GetEnumerator()
        {
            using (var reader = new StreamReader(_filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    foreach (var record in csv.GetRecords<T>())
                    {
                        yield return record;
                    }
                }
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
