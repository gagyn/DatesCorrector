using System;
using DatesCorrector.Algorithms;

namespace DatesCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathWithArgs = args.Length > 0 ? args[0] : GetArgs();

            var path = pathWithArgs.Split()[0];
            var parameters = pathWithArgs.Split()[1..];

            var fileListMaker = new FileListMaker(path, parameters);
            var fileCorrector = new FilesCorrector(fileListMaker.GetFiles(), new DefaultChooseStrategy());

            fileCorrector.CorrectFiles();
        }

        static string GetArgs()
        {
            Console.WriteLine("Input path with args:");
            return Console.ReadLine();
        }
    }
}
