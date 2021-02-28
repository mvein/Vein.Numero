using Autofac;
using FluentAssertions;
using NUnit.Framework;
using System;
using Vein.Numero.Abstractions;
using Vein.Numero.Converters;

namespace Vein.Numero.Tests
{
    [TestFixture]
    public class ConverterFactoryTests
    {
        private ContainerBuilder _builder;
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterType<Numero0To10Converter>()
                   .Keyed<INumeroConverter>(nameof(Numero0To10Converter))
                   .WithMetadata<NumeroConverterMetadata>(m => m.For(ncm => ncm.Key, nameof(Numero0To10Converter)))
                   .As<INumeroConverter>();

            _builder.Register<Func<string, int, INumeroConverter>>(c => {
                var context = c.Resolve<IComponentContext>();
                return (key, number) => {
                    return context.ResolveKeyed<INumeroConverter>(key, new TypedParameter(typeof(int), number));
                };
            });

            _builder.RegisterType<ConverterFactory>().As<IConverterFactory>();

            _container = _builder.Build();
        }

        [Test]
        public void GetConverter_WhenExists_ProperConverterExpected()
        {
            // ARRANGE
            var factory = _container.Resolve<IConverterFactory>();

            // ACT
            var converter = factory.GetConverter(0);

            // ASSERT
            converter.Should().BeOfType<Numero0To10Converter>();
        }

        [Test]
        public void GetConverter_WhenDoesNotExists_NotSupportedExceptionExpected()
        {
            // ARRANGE
            var factory = _container.Resolve<IConverterFactory>();
            Action action = () => factory.GetConverter(11);

            // ACT & ASSERT
            action.Should().Throw<NotSupportedException>().WithMessage("There is no converter that can convert given number: '11'.");
        }
    }    
}
