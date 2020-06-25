using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ImageProcessor.Imaging.Formats;

namespace ImageProcessor.Plugins.Pdf
{
    /// <summary>
    /// The plugin enabling imageprocessor to read PDF as an image source
    /// </summary>
    public class PdfFormat : FormatBase
    {
        public PdfFormat()
        {
            DesiredDpiX = 96;
            DesiredDpiY = 96;
        }
        
        /// <summary>
        /// Desired X DPI for the result document
        /// </summary>
        public int DesiredDpiX { get; set; }

        /// <summary>
        /// Desired Y DPI for the result document
        /// </summary>
        public int DesiredDpiY { get; set; }

        /// <summary>
        /// Every PDF file starts with %PDF
        /// </summary>
        /// <remarks>
        /// not according the specs, but in reality it does
        /// </remarks>
        public override byte[][] FileHeaders => new[]
        {
            Encoding.UTF8.GetBytes("%PDF") // Must be 4 bytes or less in the current version of ImageProcessor
        };

        /// <summary>
        /// the default extention of a PDF file is "PDF"
        /// </summary>
        public new string DefaultExtension => "pdf";

        /// <summary>
        /// All the extensions which are supported
        /// </summary>
        public override string[] FileExtensions => new[] { "pdf" };

        /// <summary>
        /// the mimetype of the PNG output
        /// </summary>
        public override string MimeType => "image/png";

        /// <summary>
        /// The default output format
        /// </summary>
        public override ImageFormat ImageFormat => ImageFormat.Png;

        /// <summary>
        /// This method is used to load the pdf into the current stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public override Image Load(Stream stream)
        {
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            var rasterize = new PdfRasterizer(DesiredDpiX, DesiredDpiY);
            return rasterize.Rasterize(stream);
        }
    }
}