using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero300To499Converter : NumeroX00ToX99Converter
    {
        public Numero300To499Converter(int number, IConverterFactory factory)
            : base(number, 300, 499, factory)
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

            return $"{converter.Convert()}sta";
        }
    }
}
