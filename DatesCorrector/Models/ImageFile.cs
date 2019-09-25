using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace DatesCorrector.Models
{
    class ImageFile
    {
        public FileAttributes FileAttributes { get; }

        private readonly string _path;

        public ImageFile(string path)
        {
            this._path = path;
            this.FileAttributes = File.GetAttributes(path);

            Console.WriteLine(GetDateTakenFromImage(path));
            Console.WriteLine("-----");
        }

        private DateTime GetDateTakenFromImage(string path)
        {
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Read all metadata from the image
            var directories = ImageMetadataReader.ReadMetadata(file);

            // Find the so-called Exif "SubIFD" (which may be null)
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

            // Read the DateTime tag value
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);

            if (dateTime == null)
                throw new Exception("Taken date is null.");
            
            return dateTime.Value;
        }
    }
}
