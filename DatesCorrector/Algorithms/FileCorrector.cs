using System;
using System.Collections.Generic;
using System.Text;
using DatesCorrector.Models;

namespace DatesCorrector.Algorithms
{
    class FilesCorrector
    {
        private readonly List<ImageFile> _files;
        private IChooseFileStrategy _chooseFileStrategy;

        public FilesCorrector(List<ImageFile> files, IChooseFileStrategy chooseStrategy)
        {
            if (files.Count == 0)
                throw new ArgumentException();

            this._files = files;
            this._chooseFileStrategy = chooseStrategy;
        }

        public void CorrectFiles()
        {
            foreach (var file in this._files)
            {
                if (this._chooseFileStrategy.ShouldItTakeThisFile(file))
                    CorrectTheFile(file);
            }
        }

        private void CorrectTheFile(ImageFile imageFile)
        {
            //throw new NotImplementedException();
        }
    }
}
