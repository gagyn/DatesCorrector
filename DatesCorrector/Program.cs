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

            var firstIndexOfArgs = pathWithArgs.IndexOf('-');
            
            var path = pathWithArgs.Substring(0, firstIndexOfArgs);
            var parameters = pathWithArgs.Substring(firstIndexOfArgs);

            Options options = new Options();

            var optionsParser = new OptionSet()
                { "a|ask", "ask for every file before changing.", v => options.Ask = true };

            try
            {
                optionsParser.Parse(parameters.Split(' '));
            }
            catch
            {
                Console.WriteLine("Parameters are incorrect!");
                return;
            }

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

        static bool AreParamsCorrect(string[] parameters)
        {
            if (parameters[parameters.Length - 1] == "")
                return false;

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];

                if (param == "" && parameters[i + 1].Length <= 1) // --ask => [...], [""], ["ask"], [...]
                    return false;
                if (Regex.IsMatch(param, @"^[a-zA-Z]+$") == false) // param can contain only letters
                    return false;
            }
            return true;
        }
    }
}
