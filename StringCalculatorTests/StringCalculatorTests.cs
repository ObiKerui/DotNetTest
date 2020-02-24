using StringCalculator;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1, 2", 3)]
        public void Add_GivenSimpleString_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1, -2")]
        [InlineData("1, -2, -3")]        
        public void Add_GivenNegativeValues_ThrowsCorrectException(string input) 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.Add(input));   
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        public void Add_GivenNewLine_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1,\n")]        
        public void Add__GivenIncorrectFormat_ThrowsCorrectException(string input) 
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add(input));   
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;%$\n1;2", 3)]        
        public void Add_GivenDefinedDelimiter_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }
    }
}
