using System;
using System.IO;
using DatesCorrector.Models;
using System.Linq;

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
            var dateTime = new DateTime();

            // TODO: algorithm for getting date from name
            // search for year (4 chars) => 1990 - yearNow [2001 - 2012 might be also months]
            // get month and day on the right or left of year

            // _20122012_   => not known -> try to find out how other files are named in the same directory
            // _19102012_   => 2012 year, 19.10, because 1910 year would be too early for mobile phones
            // _02122019_   => 02.12.2019

            var justName = imageFile.Path.Split('\\')[^-1];
            var separatedNames = justName.Split('_');
            
            if (separatedNames.Length == 1)
                separatedNames = justName.Split('-');

            // [IMG][20122012][232320][jpg]

            var possibleDate = separatedNames.First(x => x.Length == 8 && x.All(ch => char.GetNumericValue(ch) != -1.0)); // search for date
            // TODO: check if it is date or time

            var (yearIndex, monthIndex) = GetYearAndMonth(possibleDate);



            return dateTime;
        }

        private (int, int) GetYearAndMonth(string possibleDate) // 20121230
        {
            (int year, int month) yearAndMonth;
            (string x, string y) possibleYearAndMonth = (possibleDate.Substring(0, 4), possibleDate.Substring(4));

            if (IsItCorrectYear(possibleYearAndMonth.x))
            {
                yearAndMonth.year = int.Parse(possibleYearAndMonth.x);
                yearAndMonth.month = int.Parse(possibleYearAndMonth.y);
            }
            else if (IsItCorrectYear(possibleYearAndMonth.y) == false)
            {
                yearAndMonth.month = int.Parse(possibleYearAndMonth.x);
                yearAndMonth.year = int.Parse(possibleYearAndMonth.y);
            }
            else // left and right side may be a year
            {
                // TODO: check other files names in the directory

            }

            return yearAndMonth;
        }
        
        private bool IsItCorrectYear(string maybeYear)
        {
            var year = int.Parse(maybeYear);
            return year < 1990 && year > DateTime.Now.Year;
        }

        private (int year, int month, int day) GetDate(string possibleDate)
        {

        }
    }
}
