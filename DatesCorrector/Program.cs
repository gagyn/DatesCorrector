using System;
using System.IO;
using System.Text;
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

            try 
            {
                var fileListMaker = new FileListMaker(path, parameters);
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
