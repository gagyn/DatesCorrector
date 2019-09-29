using DatesCorrector.Models;
using System.IO;

namespace DatesCorrector.FileListMaker
{
    partial class DefaultChooseStrategy : IChooseFileStrategy
    {
        public bool ShouldItTakeThisFile(ImageFile imageFile)
        {
            if (IsFileHidden(imageFile))
                return false;

            return true;
        }

        private bool IsFileHidden(ImageFile file) => file.FileAttributes.HasFlag(FileAttributes.Hidden);
    }
}