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
            // IMG_20190912_232320.jpg => 12.09.2019 23:23:20
            // IMG_02122018_124311.jpg => 02.12.2018 12:43:11
            var date = new DateTime();

            // TODO: algotihm for getting date from name
            // search for year (4 chars) => 1990 - yearNow [2001 - 2012 might be months]
            // get month and day on the right or left of year

            return date;
        }
    }
}
