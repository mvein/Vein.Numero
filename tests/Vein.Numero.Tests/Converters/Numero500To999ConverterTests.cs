using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    public class Numero500To999ConverterTests : NumeroConverterTests<Numero500To999Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero500To999ConverterTestsTestCaseSource),
         nameof(Numero500To999ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(499)]
        [TestCase(1000)]
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
         TestCaseSource(typeof(Numero500To999ConverterTestsTestCaseSource),
         nameof(Numero500To999ConverterTestsTestCaseSource.TestCases))]
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

        [TestCase(499)]
        [TestCase(1000)]
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

    internal class Numero500To999ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(500, Consts.Number._500);

                for (int number = 1; number < 100; number++)
                {                    
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 500, $"{Consts.Number._500} ");
                }

                yield return new TestCaseData(600, Consts.Number._600);

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 600, $"{Consts.Number._600} ");
                }

                yield return new TestCaseData(700, Consts.Number._700);

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 700, $"{Consts.Number._700} ");
                }

                yield return new TestCaseData(800, Consts.Number._800);

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 800, $"{Consts.Number._800} ");
                }

                yield return new TestCaseData(900, Consts.Number._900);

                for (int number = 1; number < 100; number++)
                {
                    yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(number, 900, $"{Consts.Number._900} ");
                }
            }
        }
    }
}
