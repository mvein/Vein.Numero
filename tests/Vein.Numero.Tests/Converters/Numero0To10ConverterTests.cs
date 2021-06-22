using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture]
    public class Numero0To10ConverterTests
    {
        [Test,
         TestCaseSource(typeof(Numero0To10ConverterTestsTestCaseSource),
         nameof(Numero0To10ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
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

        [Test,
         TestCaseSource(typeof(Numero0To10ConverterTestsTestCaseSource),
         nameof(Numero0To10ConverterTestsTestCaseSource.TestCases))]
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

    internal class Numero0To10ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(0, "zero");
                yield return new TestCaseData(1, "jeden");
                yield return new TestCaseData(2, "dwa");
                yield return new TestCaseData(3, "trzy");
                yield return new TestCaseData(4, "cztery");
                yield return new TestCaseData(5, "pięć");
                yield return new TestCaseData(6, "sześć");
                yield return new TestCaseData(7, "siedem");
                yield return new TestCaseData(8, "osiem");
                yield return new TestCaseData(9, "dziewięć");
                yield return new TestCaseData(10, "dziesięć");
            }
        }
            
    }
}
