using System;

namespace Design_Patterns.Patterns.Facade.ConverterLib
{
    public class VideoConverter
    {
        public void Convert(VideoFile file, Codec codec)
        {
            Console.WriteLine($"File {file} is converted with {codec.GetType().Name} codec.");
        }
    }
}
