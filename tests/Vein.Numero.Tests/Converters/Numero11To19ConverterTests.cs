using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture(Category = "Unit")]
    public class Numero11To19ConverterTests : NumeroConverterTests<Numero11To19Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero11To19ConverterTestsTestCaseSource),
         nameof(Numero11To19ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestCase(10)]
        [TestCase(20)]
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
         TestCaseSource(typeof(Numero11To19ConverterTestsTestCaseSource),
         nameof(Numero11To19ConverterTestsTestCaseSource.TestCases))]
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

        [TestCase(10)]
        [TestCase(20)]
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

    internal class Numero11To19ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(11, NumeroHelper.Number._11);
                yield return new TestCaseData(12, NumeroHelper.Number._12);
                yield return new TestCaseData(13, NumeroHelper.Number._13);
                yield return new TestCaseData(14, NumeroHelper.Number._14);
                yield return new TestCaseData(15, NumeroHelper.Number._15);
                yield return new TestCaseData(16, NumeroHelper.Number._16);
                yield return new TestCaseData(17, NumeroHelper.Number._17);
                yield return new TestCaseData(18, NumeroHelper.Number._18);
                yield return new TestCaseData(19, NumeroHelper.Number._19);                
            }
        }
    }
}
