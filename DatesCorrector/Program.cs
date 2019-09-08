using System;

namespace DatesCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathWithArgs = args.Length > 1 ? args[1] : GetArgs();

            var path = pathWithArgs.Split()[0];
            var parameters = pathWithArgs.Split()[1..];

            var fileListMaker = new FileListMaker(path, parameters);
            var fileCorrector = new FileCorrector(fileListMaker.GetFiles());
        }

        static string GetArgs()
        {
            Console.WriteLine("Input path with args:");
            return Console.ReadLine();
        }
    }
}
