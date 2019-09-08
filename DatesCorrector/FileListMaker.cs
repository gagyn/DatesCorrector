using System;
using System.Collections.Generic;
using DatesCorrector.Models;

namespace DatesCorrector
{
    class FileListMaker
    {
        private readonly string _path;
        private readonly string[] _parameters;
        private readonly List<File> _fileLists;

        public List<File> GetFiles() => _fileLists;

        public FileListMaker(string path, string[] parameters)
        {
            this._fileLists = new List<File>();

            this._path = path ?? throw new ArgumentNullException(nameof(path));
            this._parameters = parameters;

            if (CheckIsItDirectory())
                MakeList();
            else if (CheckIsItFile())
                JustAddOneFile();
            else
                throw new System.IO.DirectoryNotFoundException();
        }

        private bool CheckIsItDirectory() => System.IO.Directory.Exists(this._path);

        private bool CheckIsItFile() => System.IO.File.Exists(this._path);

        private void JustAddOneFile() => this._fileLists.Add(new File(this._path));

        private void MakeList()
        {
            var filesNames = System.IO.Directory.GetFiles(this._path);

            foreach (var file in filesNames)
            {
                this._fileLists.Add(new File(file));
            }
        }
    }
}
