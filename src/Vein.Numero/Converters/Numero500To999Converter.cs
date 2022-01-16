using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero500To999Converter : NumeroX00ToX99Converter
    {
        public Numero500To999Converter(int number, IConverterFactory factory)
            : base(number, 500, 999, factory)
        {
        }

        protected override string ConvertRange()
        {
            var converterNumber = (Number % 100) == 0 ? null : (int?)((Number / 100) * 100);
            var converter = converterNumber is null ? null : Factory.GetConverter(Number % converterNumber.Value);

            return converterNumber is null ? $"{ConvertRangeFrom()}" : $"{ConvertRangeFrom()} {converter.Convert()}";
        }

        protected override string ConvertRangeFrom()
        {
            var converter = Factory.GetConverter(Number / 100);

            return $"{converter.Convert()}set";
        }
    }
}
