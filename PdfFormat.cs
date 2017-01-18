using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ImageProcessor.Imaging.Formats;

namespace ImageProcessor.Plugins.Pdf
{
    public class PdfFormat : FormatBase
    {
        public override byte[][] FileHeaders => new[]
        {
            Encoding.UTF8.GetBytes("%PDF") // Must be 4 bytes or less in the current version of ImageProcessor
        };

        public new string DefaultExtension => "pdf";

        public override string[] FileExtensions => new[] {"pdf"};
        public override string MimeType => "application/pdf";
        public override ImageFormat ImageFormat => ImageFormat.Png;

        public override Image Load(Stream stream)
        {
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            var rasterize = new PdfRasterizer();
            return rasterize.Rasterize(stream);
        }
    }
}