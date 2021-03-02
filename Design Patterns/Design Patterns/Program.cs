using Design_Patterns.Patterns.Facade;
using Design_Patterns.Patterns.Facade.ConverterLib;
using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new SimpleConverter(new VideoConverter());
            converter.Convert("video.mp4", "MPEG4");
        }
    }
}
