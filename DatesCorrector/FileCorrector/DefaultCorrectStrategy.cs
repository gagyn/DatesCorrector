using System;
using System.IO;
using DatesCorrector.Models;

namespace DatesCorrector.FileCorrector
{
    class DefaultCorrectStrategy : ICorrectStrategy
    {
        public virtual void CorrectFile(ImageFile imageFile)
        {
            File.SetCreationTime(imageFile.Path, GetDateTimeFromFileName(imageFile));
        }

        protected virtual DateTime GetDateTimeFromFileName(ImageFile imageFile)
        {
            // IMG_20190912.jpg => 12.09.2019
            // IMG_02122018.jpg => 02.12.2018
            var date = new DateTime();

            // TODO: algotihm for getting date from name

            return date;
        }
    }
}
