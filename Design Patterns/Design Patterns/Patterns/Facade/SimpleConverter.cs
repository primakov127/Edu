using Design_Patterns.Patterns.Facade.ConverterLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Facade
{
    public class SimpleConverter
    {
        private readonly VideoConverter _converter;

        public SimpleConverter(VideoConverter converter)
        {
            _converter = converter;
        }

        public void Convert(string filename, string format)
        {
            var file = new VideoFile(filename);
            Codec codec = null;

            if (format == "OGG")
                codec = new OGGCodec();
            else
                codec = new MPEG4Codec();

            _converter.Convert(file, codec);
        }
    }
}
