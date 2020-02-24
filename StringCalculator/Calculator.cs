using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {

        private static int _addConcise(int[] numbers) {
            
            // if there are negative values store them and throw exception telling the caller! 
            var errors = numbers.Where(i => i < 0).ToArray<int>();

            if(errors.Length > 0) {
                throw new ArgumentOutOfRangeException("negatives not allowed: " + string.Join(", ", errors));
            }

            // no errors so return the sum
            return numbers.Sum();
        }

        private static int _addQuick(int[] numbers) {
            int total = 0;
            int[] errors = {};

            // single foreach - (quicker than list Sum() method)
            // finds and stores errors if they exist too so we are 
            // only required to iterate through numbers once 
            foreach(int num in numbers) {
                if(num < 0) {
                    errors.Append(num);
                }
                total += num;
            }

            if(errors.Length > 0) {
                throw new ArgumentOutOfRangeException("negatives not allowed: " + string.Join(", ", errors));
            } else {
                return total;
            }
        }

        /// <summary>
        /// returns the sum of a delimiter seperated string of numbers
        /// </summary>
        /// <param name="numbers">delimiter seperated string of numbers</param>
        /// <returns>sum of numbers</returns>
        public static int Add(string numbers)
        {
            // can choose if we want to calaculate Add with a faster algorithm 
            // or one that's more concise for demo. purposes. 
            bool fastest = false;
            var nums = StringHelpers.StringToInts(numbers).ToArray<int>();

            return (fastest ? _addQuick(nums) : _addConcise(nums)); 
        }
    }
}
