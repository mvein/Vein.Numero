﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using Vein.Numero.Converters;
using Vein.Numero.Tests.Helpers;

namespace Vein.Numero.Tests.Converters
{
    public class Numero0To10ConverterTests : NumeroConverterTests<Numero0To10Converter>
    {
        [Test,
         TestCaseSource(typeof(Numero0To10ConverterTestsTestCaseSource),
         nameof(Numero0To10ConverterTestsTestCaseSource.TestCases))]
        public void CanConvert_WhenCalledAndNumberIsInRange_TrueAsResultExpected(int number, string _)
        {
            // ARRANGE
            var sut = CreateSut(number);

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
            var sut = CreateSut(number);

            // ACT            
            var actual = sut.CanConvert();

            // ASSERT
            actual.Should().BeFalse();
        }

        [Test,
         TestCaseSource(typeof(Numero0To10ConverterTestsTestCaseSource),
         nameof(Numero0To10ConverterTestsTestCaseSource.TestCases))]
        public void Convert_WhenCalledAndNumberIsInRange_ProperResultExpected(int number, string expected)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT            
            var actual = sut.Convert();

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(-1)]
        [TestCase(11)]
        public void Convert_WhenCalledAndNumberIsOutOfRange_ArgumentOutOfRangeExceptionExpected(int number)
        {
            // ARRANGE
            var sut = CreateSut(number);

            // ACT            
            Action act = () => sut.Convert();

            // ASSERT
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        public override Numero0To10Converter CreateSut(int number)
        {
            return new Numero0To10Converter(number);
        }
    }

    internal class Numero0To10ConverterTestsTestCaseSource
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(0, "zero");
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(1);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(2);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(3);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(4);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(5);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(6);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(7);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(8);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(9);
                yield return NumeroConverterTestsTestCaseSource.CreateTestCaseData(10);
            }
        }
            
    }
}
