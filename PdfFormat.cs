﻿using System;
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
        public override string[] FileExtensions => new[] {"pdf"};

        /// <summary>
        /// the mimetype of a pdf source
        /// </summary>
        public override string MimeType => "application/pdf";

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
            var rasterize = new PdfRasterizer();
            return rasterize.Rasterize(stream);
        }
    }
}