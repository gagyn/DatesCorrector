using System;
using DatesCorrector.Models;

namespace DatesCorrector.FileCorrector
{
    class DefaultCorrectStrategy : ICorrectStrategy
    {
        public virtual void CorrectFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
