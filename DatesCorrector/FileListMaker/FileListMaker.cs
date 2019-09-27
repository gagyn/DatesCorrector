using System;
using System.Collections.Generic;
using System.IO;
using DatesCorrector.Models;
using DatesCorrector.ParsingParameters;

namespace DatesCorrector.FileListMaker
{
    class FileListMaker
    {
        private readonly string _path;
        private readonly Options _options;
        private readonly List<ImageFile> _fileLists;

        public List<ImageFile> GetFiles() => _fileLists;

        public FileListMaker(string path, Options options)
        {
            this._fileLists = new List<ImageFile>();

            this._path = path ?? throw new ArgumentNullException(nameof(path));
            this._options = options;

            if (CheckIsItDirectory())
                MakeList();
            else if (CheckIsItFile())
                JustAddOneFile();
            else
                throw new DirectoryNotFoundException();
        }

        private bool CheckIsItDirectory() => Directory.Exists(this._path);

        private bool CheckIsItFile() => File.Exists(this._path);

        private void JustAddOneFile() => this._fileLists.Add(new ImageFile(this._path));

        private void MakeList()
        {
            var filesNames = Directory.GetFiles(this._path);

            foreach (var file in filesNames)
            {
                this._fileLists.Add(new ImageFile(file));
            }
        }
    }
}
