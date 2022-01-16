using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture]
    public class Numero100To199ConverterTests : NumeroConverterTests<Numero100To199Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero100To199ConverterTestsTestCaseSource),
         nameof(Numero100To199ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(99)]
        [TestCase(200)]
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
         TestCaseSource(typeof(Numero100To199ConverterTestsTestCaseSource),
         nameof(Numero100To199ConverterTestsTestCaseSource.TestCases))]
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

        [TestCase(99)]
        [TestCase(200)]
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

    internal class Numero100To199ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(100, "sto");

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 100, "sto ");
                }
            }
        }
    }
}
