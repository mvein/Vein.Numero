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
    [TestFixture]
    public class Numero100To199ConverterTests
    {
        [Test,
         TestCaseSource(typeof(Numero100To199ConverterTestsTestCaseSource),
         nameof(Numero100To199ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero100To199Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero100To199Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            factory.GetConverter(Arg.Any<int>())
                .Returns(x => NumeroInternalConverterFactory.Create(x.ArgAt<int>(0)));

            var sut = new Numero100To199Converter(number, factory);

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
            var factory = Substitute.For<IConverterFactory>();
            var sut = new Numero100To199Converter(number, factory);

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
                yield return new TestCaseData(101, "sto jeden");
                yield return new TestCaseData(102, "sto dwa");
                yield return new TestCaseData(103, "sto trzy");
                yield return new TestCaseData(104, "sto cztery");
                yield return new TestCaseData(105, "sto pięć");
                yield return new TestCaseData(106, "sto sześć");
                yield return new TestCaseData(107, "sto siedem");
                yield return new TestCaseData(108, "sto osiem");
                yield return new TestCaseData(109, "sto dziewięć");
                yield return new TestCaseData(110, "sto dziesięć");
                yield return new TestCaseData(111, "sto jedenaście");
                yield return new TestCaseData(112, "sto dwanaście");                
                yield return new TestCaseData(113, "sto trzynaście");
                yield return new TestCaseData(114, "sto czternaście");
                yield return new TestCaseData(115, "sto piętnaście");
                yield return new TestCaseData(116, "sto szesnaście");
                yield return new TestCaseData(117, "sto siedemnaście");
                yield return new TestCaseData(118, "sto osiemnaście");
                yield return new TestCaseData(119, "sto dziewiętnaście");
                yield return new TestCaseData(120, "sto dwadzieścia");
                yield return new TestCaseData(121, "sto dwadzieścia jeden");
                yield return new TestCaseData(122, "sto dwadzieścia dwa");
                yield return new TestCaseData(123, "sto dwadzieścia trzy");
                yield return new TestCaseData(124, "sto dwadzieścia cztery");
                yield return new TestCaseData(125, "sto dwadzieścia pięć");
                yield return new TestCaseData(126, "sto dwadzieścia sześć");
                yield return new TestCaseData(127, "sto dwadzieścia siedem");
                yield return new TestCaseData(128, "sto dwadzieścia osiem");
                yield return new TestCaseData(129, "sto dwadzieścia dziewięć");
                yield return new TestCaseData(130, "sto trzydzieści");
                yield return new TestCaseData(131, "sto trzydzieści jeden");
                yield return new TestCaseData(132, "sto trzydzieści dwa");
                yield return new TestCaseData(133, "sto trzydzieści trzy");
                yield return new TestCaseData(134, "sto trzydzieści cztery");
                yield return new TestCaseData(135, "sto trzydzieści pięć");
                yield return new TestCaseData(136, "sto trzydzieści sześć");
                yield return new TestCaseData(137, "sto trzydzieści siedem");
                yield return new TestCaseData(138, "sto trzydzieści osiem");
                yield return new TestCaseData(139, "sto trzydzieści dziewięć");
                yield return new TestCaseData(140, "sto czterdzieści");
                yield return new TestCaseData(141, "sto czterdzieści jeden");
                yield return new TestCaseData(142, "sto czterdzieści dwa");
                yield return new TestCaseData(143, "sto czterdzieści trzy");
                yield return new TestCaseData(144, "sto czterdzieści cztery");
                yield return new TestCaseData(145, "sto czterdzieści pięć");
                yield return new TestCaseData(146, "sto czterdzieści sześć");
                yield return new TestCaseData(147, "sto czterdzieści siedem");
                yield return new TestCaseData(148, "sto czterdzieści osiem");
                yield return new TestCaseData(149, "sto czterdzieści dziewięć");
                yield return new TestCaseData(150, "sto pięćdziesiąt");
                yield return new TestCaseData(151, "sto pięćdziesiąt jeden");
                yield return new TestCaseData(152, "sto pięćdziesiąt dwa");
                yield return new TestCaseData(153, "sto pięćdziesiąt trzy");
                yield return new TestCaseData(154, "sto pięćdziesiąt cztery");
                yield return new TestCaseData(155, "sto pięćdziesiąt pięć");
                yield return new TestCaseData(156, "sto pięćdziesiąt sześć");
                yield return new TestCaseData(157, "sto pięćdziesiąt siedem");
                yield return new TestCaseData(158, "sto pięćdziesiąt osiem");
                yield return new TestCaseData(159, "sto pięćdziesiąt dziewięć");
                yield return new TestCaseData(160, "sto sześćdziesiąt");
                yield return new TestCaseData(161, "sto sześćdziesiąt jeden");
                yield return new TestCaseData(162, "sto sześćdziesiąt dwa");
                yield return new TestCaseData(163, "sto sześćdziesiąt trzy");
                yield return new TestCaseData(164, "sto sześćdziesiąt cztery");
                yield return new TestCaseData(165, "sto sześćdziesiąt pięć");
                yield return new TestCaseData(166, "sto sześćdziesiąt sześć");
                yield return new TestCaseData(167, "sto sześćdziesiąt siedem");
                yield return new TestCaseData(168, "sto sześćdziesiąt osiem");
                yield return new TestCaseData(169, "sto sześćdziesiąt dziewięć");
                yield return new TestCaseData(170, "sto siedemdziesiąt");
                yield return new TestCaseData(171, "sto siedemdziesiąt jeden");
                yield return new TestCaseData(172, "sto siedemdziesiąt dwa");
                yield return new TestCaseData(173, "sto siedemdziesiąt trzy");
                yield return new TestCaseData(174, "sto siedemdziesiąt cztery");
                yield return new TestCaseData(175, "sto siedemdziesiąt pięć");
                yield return new TestCaseData(176, "sto siedemdziesiąt sześć");
                yield return new TestCaseData(177, "sto siedemdziesiąt siedem");
                yield return new TestCaseData(178, "sto siedemdziesiąt osiem");
                yield return new TestCaseData(179, "sto siedemdziesiąt dziewięć");
                yield return new TestCaseData(180, "sto osiemdziesiąt");
                yield return new TestCaseData(181, "sto osiemdziesiąt jeden");
                yield return new TestCaseData(182, "sto osiemdziesiąt dwa");
                yield return new TestCaseData(183, "sto osiemdziesiąt trzy");
                yield return new TestCaseData(184, "sto osiemdziesiąt cztery");
                yield return new TestCaseData(185, "sto osiemdziesiąt pięć");
                yield return new TestCaseData(186, "sto osiemdziesiąt sześć");
                yield return new TestCaseData(187, "sto osiemdziesiąt siedem");
                yield return new TestCaseData(188, "sto osiemdziesiąt osiem");
                yield return new TestCaseData(189, "sto osiemdziesiąt dziewięć");
                yield return new TestCaseData(190, "sto dziewięćdziesiąt");
                yield return new TestCaseData(191, "sto dziewięćdziesiąt jeden");
                yield return new TestCaseData(192, "sto dziewięćdziesiąt dwa");
                yield return new TestCaseData(193, "sto dziewięćdziesiąt trzy");
                yield return new TestCaseData(194, "sto dziewięćdziesiąt cztery");
                yield return new TestCaseData(195, "sto dziewięćdziesiąt pięć");
                yield return new TestCaseData(196, "sto dziewięćdziesiąt sześć");
                yield return new TestCaseData(197, "sto dziewięćdziesiąt siedem");
                yield return new TestCaseData(198, "sto dziewięćdziesiąt osiem");
                yield return new TestCaseData(199, "sto dziewięćdziesiąt dziewięć");
            }
        }
    }
}
