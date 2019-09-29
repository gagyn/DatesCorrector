using System;
using DatesCorrector.Models;

namespace DatesCorrector.FileCorrector
{
    class AskBeforeCorrectionStrategy : DefaultCorrectStrategy
    {
        public override void CorrectFile(ImageFile imageFile)
        {
            if (AskUserIfWantsToCorrectTheFile(imageFile))
                base.CorrectFile(imageFile);
        }

        private bool AskUserIfWantsToCorrectTheFile(ImageFile imageFile)
        {
            while (true)
            {
                Console.Write($"{imageFile.Path} - date: {imageFile.PossibleDate} - Correct the file? (y/n): ");
                var answer = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (answer)
                {
                    case 'y':
                        return true;
                    case 'n':
                        return false;
                    default:
                        continue;
                }
            }
        }
    }
}