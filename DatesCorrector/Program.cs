using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DatesCorrector.Algorithms;
using Mono.Options;
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
                var fileListMaker = new FileListMaker(parser.Path, parser.Options);
                var fileCorrector = new FilesCorrector(fileListMaker.GetFiles(), new DefaultChooseStrategy());
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
