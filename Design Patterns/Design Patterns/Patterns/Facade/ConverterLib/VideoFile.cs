using System;

namespace Design_Patterns.Patterns.Facade.ConverterLib
{
    public class VideoFile
    {
        private readonly string _filename;

        public VideoFile(string filename)
        {
            _filename = filename;
            Console.WriteLine($"File with {_filename} name is created.");
        }

        public override string ToString()
        {
            return _filename;
        }
    }
}
