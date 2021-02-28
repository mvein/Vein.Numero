using System;
using System.Collections.Generic;
using System.Linq;
using Vein.Numero.Abstractions;

namespace Vein.Numero
{
    public class ConverterFactory : IConverterFactory
    {
        readonly IEnumerable<Lazy<INumeroConverter, NumeroConverterMetadata>> _converters;
        readonly Func<string, int, INumeroConverter> _factory;

        public ConverterFactory(
            IEnumerable<Lazy<INumeroConverter, NumeroConverterMetadata>> converters,
            Func<string, int, INumeroConverter> factory)
        {
            _converters = converters;
            _factory = factory;
        }

        public INumeroConverter GetConverter(int number)
        {
            INumeroConverter result = null;
            foreach (var key in _converters.Select(x => x.Metadata.Key).ToList())
            {
                var converter = _factory(key, number);
                if (converter.CanConvert())
                {
                    result = converter;
                    break;
                }
            }

            return result ?? throw new NotSupportedException($"There is no converter that can convert given number: '{number}'.");
        }
    }

    /*
     * https://docs.microsoft.com/en-us/dotnet/standard/frameworks
     * https://dotnetfalcon.com/versioning/
     * https://stackoverflow.com/questions/9066200/passing-parameters-to-constructors-using-autofac
     * https://autofaccn.readthedocs.io/en/latest/resolve/parameters.html
     * https://stackoverflow.com/questions/14061472/get-all-registered-implementations-of-an-interface-in-autofac/14061978
     * https://stackoverflow.com/questions/24369861/get-a-list-of-all-registered-objects-implementing-a-certain-interface/24389885
     * https://autofaccn.readthedocs.io/en/latest/advanced/keyed-services.html
     * https://stackoverflow.com/questions/31858656/using-autofacs-iindex-to-resolve-multiple-keyed-instances
     */
}
