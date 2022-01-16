using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero200To299Converter : NumeroX00ToX99Converter
    {
        private readonly IConverterFactory _factory;

        public Numero200To299Converter(int number, IConverterFactory factory)
            : base(number, 200, 299)
        {
            _factory = factory;
        }

        protected override string ConvertRange(int number)
        {
            var converter = _factory.GetConverter(number % 200);

            return $"{ConvertRangeFrom()} {converter.Convert()}";
        }

        protected override string ConvertRangeFrom()
        {
            return Consts.Number._200;
        }
    }
}
