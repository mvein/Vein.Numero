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
            factory.GetConverter(Arg.Any<int>()).Returns(x => NumeroInternalConverterFactory.Create(x.ArgAt<int>(0)));
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

    internal class Numero20To99ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(20, NumeroHelper.Number._20);
                yield return new TestCaseData(21, NumeroHelper.Number._21);
                yield return new TestCaseData(22, NumeroHelper.Number._22);
                yield return new TestCaseData(23, NumeroHelper.Number._23);
                yield return new TestCaseData(24, NumeroHelper.Number._24);
                yield return new TestCaseData(25, NumeroHelper.Number._25);
                yield return new TestCaseData(26, NumeroHelper.Number._26);
                yield return new TestCaseData(27, NumeroHelper.Number._27);
                yield return new TestCaseData(28, NumeroHelper.Number._28);
                yield return new TestCaseData(29, NumeroHelper.Number._29);
                yield return new TestCaseData(30, NumeroHelper.Number._30);
                yield return new TestCaseData(31, NumeroHelper.Number._31);
                yield return new TestCaseData(32, NumeroHelper.Number._32);
                yield return new TestCaseData(33, NumeroHelper.Number._33);
                yield return new TestCaseData(34, NumeroHelper.Number._34);
                yield return new TestCaseData(35, NumeroHelper.Number._35);
                yield return new TestCaseData(36, NumeroHelper.Number._36);
                yield return new TestCaseData(37, NumeroHelper.Number._37);
                yield return new TestCaseData(38, NumeroHelper.Number._38);
                yield return new TestCaseData(39, NumeroHelper.Number._39);
                yield return new TestCaseData(40, NumeroHelper.Number._40);
                yield return new TestCaseData(41, NumeroHelper.Number._41);
                yield return new TestCaseData(42, NumeroHelper.Number._42);
                yield return new TestCaseData(43, NumeroHelper.Number._43);
                yield return new TestCaseData(44, NumeroHelper.Number._44);
                yield return new TestCaseData(45, NumeroHelper.Number._45);
                yield return new TestCaseData(46, NumeroHelper.Number._46);
                yield return new TestCaseData(47, NumeroHelper.Number._47);
                yield return new TestCaseData(48, NumeroHelper.Number._48);
                yield return new TestCaseData(49, NumeroHelper.Number._49);
                yield return new TestCaseData(50, NumeroHelper.Number._50);
                yield return new TestCaseData(51, NumeroHelper.Number._51);
                yield return new TestCaseData(52, NumeroHelper.Number._52);
                yield return new TestCaseData(53, NumeroHelper.Number._53);
                yield return new TestCaseData(54, NumeroHelper.Number._54);
                yield return new TestCaseData(55, NumeroHelper.Number._55);
                yield return new TestCaseData(56, NumeroHelper.Number._56);
                yield return new TestCaseData(57, NumeroHelper.Number._57);
                yield return new TestCaseData(58, NumeroHelper.Number._58);
                yield return new TestCaseData(59, NumeroHelper.Number._59);
                yield return new TestCaseData(60, NumeroHelper.Number._60);
                yield return new TestCaseData(61, NumeroHelper.Number._61);
                yield return new TestCaseData(62, NumeroHelper.Number._62);
                yield return new TestCaseData(63, NumeroHelper.Number._63);
                yield return new TestCaseData(64, NumeroHelper.Number._64);
                yield return new TestCaseData(65, NumeroHelper.Number._65);
                yield return new TestCaseData(66, NumeroHelper.Number._66);
                yield return new TestCaseData(67, NumeroHelper.Number._67);
                yield return new TestCaseData(68, NumeroHelper.Number._68);
                yield return new TestCaseData(69, NumeroHelper.Number._69);
                yield return new TestCaseData(70, NumeroHelper.Number._70);
                yield return new TestCaseData(71, NumeroHelper.Number._71);
                yield return new TestCaseData(72, NumeroHelper.Number._72);
                yield return new TestCaseData(73, NumeroHelper.Number._73);
                yield return new TestCaseData(74, NumeroHelper.Number._74);
                yield return new TestCaseData(75, NumeroHelper.Number._75);
                yield return new TestCaseData(76, NumeroHelper.Number._76);
                yield return new TestCaseData(77, NumeroHelper.Number._77);
                yield return new TestCaseData(78, NumeroHelper.Number._78);
                yield return new TestCaseData(79, NumeroHelper.Number._79);
                yield return new TestCaseData(80, NumeroHelper.Number._80);
                yield return new TestCaseData(81, NumeroHelper.Number._81);
                yield return new TestCaseData(82, NumeroHelper.Number._82);
                yield return new TestCaseData(83, NumeroHelper.Number._83);
                yield return new TestCaseData(84, NumeroHelper.Number._84);
                yield return new TestCaseData(85, NumeroHelper.Number._85);
                yield return new TestCaseData(86, NumeroHelper.Number._86);
                yield return new TestCaseData(87, NumeroHelper.Number._87);
                yield return new TestCaseData(88, NumeroHelper.Number._88);
                yield return new TestCaseData(89, NumeroHelper.Number._89);
                yield return new TestCaseData(90, NumeroHelper.Number._90);
                yield return new TestCaseData(91, NumeroHelper.Number._91);
                yield return new TestCaseData(92, NumeroHelper.Number._92);
                yield return new TestCaseData(93, NumeroHelper.Number._93);
                yield return new TestCaseData(94, NumeroHelper.Number._94);
                yield return new TestCaseData(95, NumeroHelper.Number._95);
                yield return new TestCaseData(96, NumeroHelper.Number._96);
                yield return new TestCaseData(97, NumeroHelper.Number._97);
                yield return new TestCaseData(98, NumeroHelper.Number._98);
                yield return new TestCaseData(99, NumeroHelper.Number._99);
            }
        }
    }
}
