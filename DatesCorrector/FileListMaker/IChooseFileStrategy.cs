using DatesCorrector.Models;

namespace DatesCorrector.FileListMaker
{
    internal interface IChooseFileStrategy
    {
        bool ShouldItTakeThisFile(ImageFile imageFile);
    }
}