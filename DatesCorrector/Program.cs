using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DatesCorrector.Algorithms;
using Mono.Options;

namespace DatesCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathWithArgs = args.Length > 0 ? args[0] : GetArgs();
            
            var (path, parameters) = SplitPathAndArgs(pathWithArgs);

            Options options;

            if (parameters != null)
            {
                options = ParseParameters(parameters);
            }
            else
                options = new Options(); // create options with default values

            try 
            {
                var fileListMaker = new FileListMaker(path, options);
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

        static (string, string) SplitPathAndArgs(string pathWithArgs)
        {
            var firstIndexOfArgs = pathWithArgs.IndexOf('-');
            
            if (firstIndexOfArgs == -1)
                return (pathWithArgs, null);

            var path = pathWithArgs.Substring(0, firstIndexOfArgs - 1);
            var args = pathWithArgs.Substring(firstIndexOfArgs);
            return (path, args);
        }

        static Options ParseParameters(string parameters)
        {
            var options = new Options();

            var optionsParser = new OptionSet() {
                { "a|ask", "ask for every file before changing.", s => options.Ask = true },
            };

            try
            {
                optionsParser.Parse(parameters.Split(' '));
            }
            catch
            {
                throw new Exception("Parameters are incorrect!");
            }
            
            return options;
        }
    }
}
