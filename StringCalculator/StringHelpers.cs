using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class StringHelpers
    {
        // create a regex to match delimiters
        static readonly Regex _regex = new Regex("^//(.*)\n");
        
        /// <summary>
        /// converts a string of comma separated list of numbers into collection of ints
        /// </summary>
        /// <param name="input">string of comma separated list of numbers</param>
        /// <returns>collection of ints</returns>
        public static IEnumerable<int> StringToInts(string input)
        {
            // handle erros with bad string format
            var errStr = ",\n";
            if(input.Contains(errStr)) 
            {
                throw new ArgumentException("string cannot contain: " + errStr);
            }

            // Match the regular expression pattern against a text string.
            var groups = _regex.Match(input).Groups;

            // remove the custom delimiter from the input string if it exists
            var inputStr = input;
            if(groups.Count > 0) 
            {
                inputStr = input.Substring(groups[0].Length);
            }

            // assign the custom delimiters if they exist
            var delims = ",";
            if(groups.Count == 2) 
            {
                delims = groups[1].Value;
            }
            var delimstr = delims + '\n';            
            
            string[] splitInput = inputStr.Split(delimstr.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var output = new List<int>();
            foreach (var numberString in splitInput)
            {
                output.Add(int.Parse(numberString));
            }
            return output;
        }
    }
}
