using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace DatesCorrector.Models
{
    class FileNotPhotoException : Exception
    {
        public override string Message => "File is not a photo.";
    }

    class ImageFile
    {
        public FileAttributes FileAttributes { get; }
        public string Path { get; }
        public DateTime? PossibleDate { get; }

        public ImageFile(string path)
        {
            this.Path = path;
            this.FileAttributes = File.GetAttributes(path);

            if (IsFilePhotoFile(path) == false)
                throw new FileNotPhotoException();

            this.PossibleDate = GetDateTakenFromImage();
        }

        private bool IsFilePhotoFile(string path)
        {
            const string jpg = "FFD8";
            const string png = "8950";
            
            var imageFormats = new List<string> { jpg, png };

            var stream = new StreamReader(path).BaseStream;
            var byte1 = stream.ReadByte();
            var byte2 = stream.ReadByte();
            
            var bytesString = byte1.ToString("X2") + byte2.ToString("X2");

            return imageFormats.Any(format => format.Equals(bytesString));
        }

        private DateTime? GetDateTakenFromImage()
        {
            var file = new FileStream(this.Path, FileMode.Open, FileAccess.Read);

            // Read all metadata from the image
            var directories = ImageMetadataReader.ReadMetadata(file);

            // Find the so-called Exif "SubIFD" (which may be null)
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

            // Read the DateTime tag value
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);

            return dateTime;
        }
    }
}
