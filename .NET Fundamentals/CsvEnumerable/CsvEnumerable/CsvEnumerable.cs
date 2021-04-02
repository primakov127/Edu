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
            var reader = new StreamReader(_filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var record in csv.GetRecords<T>())
            {
                yield return record;
            }

            csv.Dispose();
            reader.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
