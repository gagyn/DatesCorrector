using System;
using System.Collections.Generic;
using System.Text;
using DatesCorrector.Models;

namespace DatesCorrector
{
    class FileCorrector
    {
        private List<File> _files;

        public FileCorrector(List<File> files)
        {
            if (files.Count == 0)
                throw new ArgumentException();

            this._files = files;
        }
    }
}
