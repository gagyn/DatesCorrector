using DatesCorrector.Models;

namespace DatesCorrector.Algorithms
{
    internal interface IChooseFileStrategy
    {
        bool ShouldItTakeThisFile(ImageFile imageFile);
    }
}