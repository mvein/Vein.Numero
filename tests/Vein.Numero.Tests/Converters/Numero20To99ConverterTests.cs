using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Abstractions;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture(Category = "Unit")]
    public class Numero20To99ConverterTests : NumeroConverterTests<Numero20To99Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero20To99ConverterTestsTestCaseSource),
         nameof(Numero20To99ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(19)]
        [TestCase(100)]
        public void CanConvert_WhenCalledAndNumberIsOutOfRange_FalseAsResultExpected(int number)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT            
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeFalse();
        }

        [Test,
         TestCaseSource(typeof(Numero20To99ConverterTestsTestCaseSource),
         nameof(Numero20To99ConverterTestsTestCaseSource.TestCases))]
        public void Convert_WhenCalledAndNumberIsInRange_ProperResultExpected(int number, string expected)
        {
            // ARRANGE
            Factory.GetConverter(Arg.Any<int>())
                .Returns(x => NumeroInternalConverterFactory.Create(x.ArgAt<int>(0)));

            var sut = CreateSut(number);

            // ACT            
            var actual = sut.Convert();

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(19)]
        [TestCase(100)]
        public void Convert_WhenCalledAndNumberIsOutOfRange_ArgumentOutOfRangeExceptionExpected(int number)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT            
            Action act = () => sut.Convert();

            // ASSERT
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }

    internal class Numero20To99ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                for (int number = 20; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number);
                }
            }
        }
    }
}
