using DatesCorrector.Models;

namespace DatesCorrector.Algorithms
{
    class DefaultChooseStrategy : IChooseFileStrategy
    {
        public bool ShouldItTakeThisFile(ImageFile imageFile)
        {
            return false;
        }


    }
}