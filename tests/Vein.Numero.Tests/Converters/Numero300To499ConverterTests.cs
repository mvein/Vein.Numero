using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    public class Numero300To499ConverterTests : NumeroConverterTests<Numero300To499Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero300To499ConverterTestsTestCaseSource),
         nameof(Numero300To499ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(299)]
        [TestCase(500)]
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
         TestCaseSource(typeof(Numero300To499ConverterTestsTestCaseSource),
         nameof(Numero300To499ConverterTestsTestCaseSource.TestCases))]
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

        [TestCase(299)]
        [TestCase(500)]
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

    internal class Numero300To499ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(300, Consts.Number._300);

                for (int number = 1; number < 100; number++)
                {                    
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 300, $"{Consts.Number._300} ");
                }

                yield return new TestCaseData(400, Consts.Number._400);

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 400, $"{Consts.Number._400} ");
                }
            }
        }
    }
}
