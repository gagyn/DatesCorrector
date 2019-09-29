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
                Console.WriteLine("Correct the file? (y/n)");

                switch (Console.ReadKey().KeyChar)
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