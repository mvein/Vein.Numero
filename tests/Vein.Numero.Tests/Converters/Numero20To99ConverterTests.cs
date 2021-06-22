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
    public class Numero20To99ConverterTests
    {
        [Test,
         TestCaseSource(typeof(Numero20To99ConverterTestsTestCaseSource),
         nameof(Numero20To99ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero20To99Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero20To99Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            factory.GetConverter(Arg.Any<int>()).Returns(x => new Numero20To99InternalConverter(x.ArgAt<int>(0)));
            var sut = new Numero20To99Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero20To99Converter(number, factory);

            // ACT            
            Action act = () => sut.Convert();

            // ASSERT
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }

    internal class Numero20To99InternalConverter : INumeroConverter
    {
        private readonly int _number;

        public Numero20To99InternalConverter(int number)
        {
            _number = number;
        }

        public bool CanConvert()
        {
            throw new NotImplementedException();
        }

        public string Convert()
        {
#if NETCOREAPP3_1
            return _number switch
            {
                1 => "jeden",
                2 => "dwa",
                3 => "trzy",
                4 => "cztery",
                5 => "pięć",
                6 => "sześć",
                7 => "siedem",
                8 => "osiem",
                9 => "dziewięć",
                _ => throw new ArgumentOutOfRangeException(),
            };
#else
            switch (_number)
	        {
                case 1: return "jeden";
                case 2: return "dwa";
                case 3: return "trzy";
                case 4: return "cztery";
                case 5: return "pięć";
                case 6: return "sześć";
                case 7: return "siedem";
                case 8: return "osiem";
                case 9: return "dziewięć";
                default: throw new ArgumentOutOfRangeException();
	        }
#endif
        }
    }

    internal class Numero20To99ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(20, "dwadzieścia");
                yield return new TestCaseData(21, "dwadzieścia jeden");
                yield return new TestCaseData(22, "dwadzieścia dwa");
                yield return new TestCaseData(23, "dwadzieścia trzy");
                yield return new TestCaseData(24, "dwadzieścia cztery");
                yield return new TestCaseData(25, "dwadzieścia pięć");
                yield return new TestCaseData(26, "dwadzieścia sześć");
                yield return new TestCaseData(27, "dwadzieścia siedem");
                yield return new TestCaseData(28, "dwadzieścia osiem");
                yield return new TestCaseData(29, "dwadzieścia dziewięć");
                yield return new TestCaseData(30, "trzydzieści");
                yield return new TestCaseData(31, "trzydzieści jeden");
                yield return new TestCaseData(32, "trzydzieści dwa");
                yield return new TestCaseData(33, "trzydzieści trzy");
                yield return new TestCaseData(34, "trzydzieści cztery");
                yield return new TestCaseData(35, "trzydzieści pięć");
                yield return new TestCaseData(36, "trzydzieści sześć");
                yield return new TestCaseData(37, "trzydzieści siedem");
                yield return new TestCaseData(38, "trzydzieści osiem");
                yield return new TestCaseData(39, "trzydzieści dziewięć");
                yield return new TestCaseData(40, "czterdzieści");
                yield return new TestCaseData(41, "czterdzieści jeden");
                yield return new TestCaseData(42, "czterdzieści dwa");
                yield return new TestCaseData(43, "czterdzieści trzy");
                yield return new TestCaseData(44, "czterdzieści cztery");
                yield return new TestCaseData(45, "czterdzieści pięć");
                yield return new TestCaseData(46, "czterdzieści sześć");
                yield return new TestCaseData(47, "czterdzieści siedem");
                yield return new TestCaseData(48, "czterdzieści osiem");
                yield return new TestCaseData(49, "czterdzieści dziewięć");
                yield return new TestCaseData(50, "pięćdziesiąt");
                yield return new TestCaseData(51, "pięćdziesiąt jeden");
                yield return new TestCaseData(52, "pięćdziesiąt dwa");
                yield return new TestCaseData(53, "pięćdziesiąt trzy");
                yield return new TestCaseData(54, "pięćdziesiąt cztery");
                yield return new TestCaseData(55, "pięćdziesiąt pięć");
                yield return new TestCaseData(56, "pięćdziesiąt sześć");
                yield return new TestCaseData(57, "pięćdziesiąt siedem");
                yield return new TestCaseData(58, "pięćdziesiąt osiem");
                yield return new TestCaseData(59, "pięćdziesiąt dziewięć");
                yield return new TestCaseData(60, "sześćdziesiąt");
                yield return new TestCaseData(61, "sześćdziesiąt jeden");
                yield return new TestCaseData(62, "sześćdziesiąt dwa");
                yield return new TestCaseData(63, "sześćdziesiąt trzy");
                yield return new TestCaseData(64, "sześćdziesiąt cztery");
                yield return new TestCaseData(65, "sześćdziesiąt pięć");
                yield return new TestCaseData(66, "sześćdziesiąt sześć");
                yield return new TestCaseData(67, "sześćdziesiąt siedem");
                yield return new TestCaseData(68, "sześćdziesiąt osiem");
                yield return new TestCaseData(69, "sześćdziesiąt dziewięć");
                yield return new TestCaseData(70, "siedemdziesiąt");
                yield return new TestCaseData(71, "siedemdziesiąt jeden");
                yield return new TestCaseData(72, "siedemdziesiąt dwa");
                yield return new TestCaseData(73, "siedemdziesiąt trzy");
                yield return new TestCaseData(74, "siedemdziesiąt cztery");
                yield return new TestCaseData(75, "siedemdziesiąt pięć");
                yield return new TestCaseData(76, "siedemdziesiąt sześć");
                yield return new TestCaseData(77, "siedemdziesiąt siedem");
                yield return new TestCaseData(78, "siedemdziesiąt osiem");
                yield return new TestCaseData(79, "siedemdziesiąt dziewięć");
                yield return new TestCaseData(80, "osiemdziesiąt");
                yield return new TestCaseData(81, "osiemdziesiąt jeden");
                yield return new TestCaseData(82, "osiemdziesiąt dwa");
                yield return new TestCaseData(83, "osiemdziesiąt trzy");
                yield return new TestCaseData(84, "osiemdziesiąt cztery");
                yield return new TestCaseData(85, "osiemdziesiąt pięć");
                yield return new TestCaseData(86, "osiemdziesiąt sześć");
                yield return new TestCaseData(87, "osiemdziesiąt siedem");
                yield return new TestCaseData(88, "osiemdziesiąt osiem");
                yield return new TestCaseData(89, "osiemdziesiąt dziewięć");
                yield return new TestCaseData(90, "dziewięćdziesiąt");
                yield return new TestCaseData(91, "dziewięćdziesiąt jeden");
                yield return new TestCaseData(92, "dziewięćdziesiąt dwa");
                yield return new TestCaseData(93, "dziewięćdziesiąt trzy");
                yield return new TestCaseData(94, "dziewięćdziesiąt cztery");
                yield return new TestCaseData(95, "dziewięćdziesiąt pięć");
                yield return new TestCaseData(96, "dziewięćdziesiąt sześć");
                yield return new TestCaseData(97, "dziewięćdziesiąt siedem");
                yield return new TestCaseData(98, "dziewięćdziesiąt osiem");
                yield return new TestCaseData(99, "dziewięćdziesiąt dziewięć");
            }
        }
    }
}
