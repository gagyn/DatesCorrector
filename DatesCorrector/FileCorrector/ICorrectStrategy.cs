using DatesCorrector.Models;

namespace DatesCorrector.FileCorrector
{
    interface ICorrectStrategy
    {
        void CorrectFile(ImageFile imageFile);
    }
}
