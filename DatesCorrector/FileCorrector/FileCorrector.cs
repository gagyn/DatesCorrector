using System;
using System.Collections.Generic;
using System.Text;
using DatesCorrector.Models;
using DatesCorrector.ParsingParameters;

namespace DatesCorrector.Algorithms
{
    class FilesCorrector
    {
        private readonly List<ImageFile> _files;
        private readonly IChooseFileStrategy _chooseFileStrategy;
        private readonly Options _options;

        public FilesCorrector(List<ImageFile> files, IChooseFileStrategy chooseStrategy, Options options)
        {
            if (files.Count == 0)
                throw new ArgumentException();

            this._files = files;
            this._chooseFileStrategy = chooseStrategy;
            this._options = options;
        }

        public void CorrectFiles()
        {
            foreach (var file in this._files)
            {
                if (this._chooseFileStrategy.ShouldItTakeThisFile(file))
                    CorrectFileDateTimeAttribute(file);
            }
        }

        private void CorrectFileDateTimeAttribute(ImageFile imageFile)
        {
            //throw new NotImplementedException();
        }
    }
}
