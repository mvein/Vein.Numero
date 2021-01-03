using FluentAssertions;
using NUnit.Framework;
using System;
using Vein.Numero.Converters;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture]
    public class Numero0To10ConverterTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number)
        {
            // ARRANGE
            var sut = new Numero0To10Converter(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(-1)]
        [TestCase(11)]
        public void CanConvert_WhenCalledAndNumberIsOutOfRange_FalseAsResultExpected(int number)
        {
            // ARRANGE
            var sut = new Numero0To10Converter(number);

            // ACT            
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestCase(0, "zero")]
        [TestCase(1, "jeden")]
        [TestCase(2, "dwa")]
        [TestCase(3, "trzy")]
        [TestCase(4, "cztery")]
        [TestCase(5, "pięć")]
        [TestCase(6, "sześć")]
        [TestCase(7, "siedem")]
        [TestCase(8, "osiem")]
        [TestCase(9, "dziewięć")]
        [TestCase(10, "dziesięć")]
        public void Convert_WhenCalledAndNumberIsInRange_ProperResultExpected(int number, string expected)
        {
            // ARRANGE
            var sut = new Numero0To10Converter(number);

            // ACT            
            var actual = sut.Convert();

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(-1)]
        [TestCase(11)]
        public void Convert_WhenCalledAndNumberIsOutOfRange_ArgumentOutOfRangeExceptionExpected(int number)
        {
            // ARRANGE
            var sut = new Numero0To10Converter(number);

            // ACT            
            Action act = () => sut.Convert();

            // ASSERT
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
