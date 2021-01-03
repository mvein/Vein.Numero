using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using Vein.Numero.Abstractions;
using Vein.Numero.Converters;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture]
    public class Numero11To19ConverterTests
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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero11To19Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero11To19Converter(number, factory);

            // ACT            
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestCase(11, "jedenaście")]
        [TestCase(12, "dwanaście")]
        [TestCase(13, "trzynaście")]
        [TestCase(14, "czternaście")]
        [TestCase(15, "pięnaście")]
        [TestCase(16, "szesnaście")]
        [TestCase(17, "siedemnaście")]
        [TestCase(18, "osiemnaście")]
        [TestCase(19, "dziewiętnaście")]
        public void Convert_WhenCalledAndNumberIsInRange_ProperResultExpected(int number, string expected)
        {
            // ARRANGE
            var factory = Substitute.For<IConverterFactory>();
            var converter = Substitute.For<IConverterFactory>();
            factory.GetConverter(Arg.Any<int>()).Returns(x => new InternalConverter(x.ArgAt<int>(0)));
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

    internal class InternalConverter : INumeroConverter
    {
        private readonly int _number;

        public InternalConverter(int number)
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
}
