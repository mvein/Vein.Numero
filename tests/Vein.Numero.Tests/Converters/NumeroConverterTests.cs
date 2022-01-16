using NSubstitute;
using NUnit.Framework;
using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Tests.Converters
{
    [TestFixture(Category = "Unit")]
    public abstract class NumeroConverterTests<T> where T : INumeroConverter
    {
        protected IConverterFactory Factory;

        [SetUp]
        public void SetUp()
        {
            Factory = Substitute.For<IConverterFactory>();
        }

        public virtual T CreateSut(int number)
        {
            return (T)Activator.CreateInstance(typeof(T), number, Factory);
        }
    }
}
