using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            Console.WriteLine(FileAttributes);
            Console.WriteLine("-----");
        }
    }
}
