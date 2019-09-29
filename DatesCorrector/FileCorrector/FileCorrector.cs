using System;
using System.Collections.Generic;
using DatesCorrector.FileListMaker;
using DatesCorrector.Models;
using DatesCorrector.ParsingParameters;

namespace DatesCorrector.FileCorrector
{
    class FilesCorrector
    {
        private readonly List<ImageFile> _files;
        private readonly IChooseFileStrategy _chooseFileStrategy;
        private readonly ICorrectStrategy _correctStrategy;
        public FilesCorrector(List<ImageFile> files, IChooseFileStrategy chooseStrategy, Options options)
        {
            if (files.Count == 0)
                throw new ArgumentException();

            this._files = files;
            this._chooseFileStrategy = chooseStrategy;
            this._correctStrategy = ChooseStrategy(options);
        }

        public void CorrectFiles()
        {
            foreach (var file in _files)
            {
                if (_chooseFileStrategy.ShouldItTakeThisFile(file))
                    _correctStrategy.CorrectFile(file);
            }
        }

        private ICorrectStrategy ChooseStrategy(Options options)
        {
            ICorrectStrategy correctStrategy;

            if (options.Ask)
                correctStrategy = new AskBeforeCorrectionStrategy();
            else
                correctStrategy = new DefaultCorrectStrategy();

            return correctStrategy;
        }
    }
}
