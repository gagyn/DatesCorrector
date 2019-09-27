using System;
using System.IO;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace DatesCorrector.Models
{
    class ImageFile
    {
        public FileAttributes FileAttributes { get; }
        public string Path { get; }
        public DateTime? PossibleDate { get; }

        public ImageFile(string path)
        {
            this.Path = path;
            this.FileAttributes = File.GetAttributes(path);

            this.PossibleDate = GetDateTakenFromImage();
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
