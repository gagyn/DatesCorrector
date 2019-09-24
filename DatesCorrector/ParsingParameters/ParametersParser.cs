using Mono.Options;
using System;

namespace DatesCorrector.ParsingParameters
{
    class ParametersParser
    {
        public Options Options => _options;

        public string Path => _path;

        private Options _options;
        private string _path;
        public ParametersParser(string pathWithArgs)
        {
            var (path, parameters) = SplitPathAndArgs(pathWithArgs);

            Options options;
            if (parameters != null)
            {
                options = ParseParameters(parameters);
            }
            else
                options = new Options(); // create options with default values

            this._options = options;
            this._path = path;
        }

        private (string, string) SplitPathAndArgs(string pathWithArgs)
        {
            var firstIndexOfArgs = pathWithArgs.IndexOf('-');
            
            if (firstIndexOfArgs == -1)
                return (pathWithArgs, null);

            var path = pathWithArgs.Substring(0, firstIndexOfArgs - 1);
            var args = pathWithArgs.Substring(firstIndexOfArgs);
            return (path, args);
        }

        private Options ParseParameters(string parameters)
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