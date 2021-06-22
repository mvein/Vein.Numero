using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Abstractions;
using Vein.Numero.Converters;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture]
    public class Numero11To19ConverterTests
    {
        [Test,
         TestCaseSource(typeof(Numero11To19ConverterTestsTestCaseSource),
         nameof(Numero11To19ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero11To19Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero11To19Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var converter = Substitute.For<IConverterFactory>();
            factory.GetConverter(Arg.Any<int>()).Returns(x => new Numero11To19InternalConverter(x.ArgAt<int>(0)));
            var sut = new Numero11To19Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero11To19Converter(number, factory);

            // ACT            
            Action act = () => sut.Convert();

            // ASSERT
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }

    internal class Numero11To19InternalConverter : INumeroConverter
    {
        private readonly int _number;

        public Numero11To19InternalConverter(int number)
        {
            _number = number;
        }

        public bool CanConvert()
        {
            throw new NotImplementedException();
        }

        public string Convert()
        {
            switch (_number)
            {
                case 1:
                    return "jeden";
                case 2:
                    return "dwa";
                case 3:
                    return "trzy";
                case 7:
                    return "siedem";
                case 8:
                    return "osiem";
                default:
                    throw new ArgumentOutOfRangeException();
            };
        }
    }

    internal class Numero11To19ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(11, "jedenaście");
                yield return new TestCaseData(12, "dwanaście");
                yield return new TestCaseData(13, "trzynaście");
                yield return new TestCaseData(14, "czternaście");
                yield return new TestCaseData(15, "piętnaście");
                yield return new TestCaseData(16, "szesnaście");
                yield return new TestCaseData(17, "siedemnaście");
                yield return new TestCaseData(18, "osiemnaście");
                yield return new TestCaseData(19, "dziewiętnaście");
            }
        }
    }
}
