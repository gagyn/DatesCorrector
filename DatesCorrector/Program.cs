using System;
using System.IO;
using DatesCorrector.FileCorrector;
using DatesCorrector.FileListMaker;
using DatesCorrector.ParsingParameters;

namespace DatesCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathWithArgs = args.Length > 0 ? args[0] : GetArgs();

            var parser = new ParametersParser(pathWithArgs);

            try 
            {
                var fileListMaker = new FileListMaker.FileListMaker(parser.Path, parser.Options);
                var fileCorrector = new FilesCorrector(fileListMaker.GetFiles(), new DefaultChooseStrategy(), parser.Options);
                fileCorrector.CorrectFiles();

                Console.WriteLine("Work done!");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static string GetArgs()
        {
            Console.WriteLine("Input path with args:");
            return Console.ReadLine();
        }
    }
}
