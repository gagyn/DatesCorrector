using DatesCorrector.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DatesCorrector.FileListMaker
{
    class DefaultChooseStrategy : IChooseFileStrategy
    {
        public bool ShouldItTakeThisFile(ImageFile imageFile)
        {
            if (IsFileHidden(imageFile))
                return false;
            
            if(IsFilePhotoFile(imageFile) == false)
                return false;

            return true;
        }

        private bool IsFileHidden(ImageFile file) => file.FileAttributes.HasFlag(FileAttributes.Hidden);

        private bool IsFilePhotoFile(ImageFile file)
        {
            var jpg = "FFD8";
            var png = "8950";
            
            var imageFormats = new List<string> { jpg, png };

            Stream stream = (new StreamReader(file.Path)).BaseStream;
            var byte1 = stream.ReadByte();
            var byte2 = stream.ReadByte();
            
            var bytesString = byte1.ToString("X2") + byte2.ToString("X2");

            return imageFormats.Any(format => format.Equals(bytesString));
        }
    }
}