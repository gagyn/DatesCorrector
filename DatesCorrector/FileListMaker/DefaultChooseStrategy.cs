using DatesCorrector.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DatesCorrector.FileListMaker
{
    class DefaultChooseStrategy : IChooseFileStrategy
    {
        private ImageFile _imageFile;

        public bool ShouldItTakeThisFile(ImageFile imageFile)
        {
            this._imageFile = imageFile;

            if (IsFileHidden())
                return false;
            
            if(IsFilePhotoFile() == false)
                return false;

            return true;
        }

        private bool IsFileHidden() => this._imageFile.FileAttributes.HasFlag(FileAttributes.Hidden);

        private bool IsFilePhotoFile()
        {
            var jpg = "FFD8";
            var png = "8950";
            
            var imageFormats = new List<string> { jpg, png };

            Stream stream = (new StreamReader(this._imageFile.Path)).BaseStream;
            var byte1 = stream.ReadByte();
            var byte2 = stream.ReadByte();
            
            var bytesString = byte1.ToString("X2") + byte2.ToString("X2");

            return imageFormats.Any(format => format.Equals(bytesString));
        }
    }
}