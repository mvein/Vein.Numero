using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public abstract class NumeroX00ToX99Converter : NumeroConverter
    {
        protected readonly int RangeFrom;
        private readonly int _rangeTo;

        protected readonly IConverterFactory Factory;

        protected NumeroX00ToX99Converter(
            int number,
            int rangeFrom,
            int rangeTo,
            IConverterFactory factory) : base(number)
        {
            RangeFrom = rangeFrom;
            _rangeTo = rangeTo;
            Factory = factory;
        }

        public override bool CanConvert()
        {
            return Number >= RangeFrom && Number <= _rangeTo;
        }

        public override string Convert()
        {
            return Number switch
            {
                _ when Number == RangeFrom => ConvertRangeFrom(),
                _ when Number > RangeFrom && Number <= _rangeTo => ConvertRange(),
                _ => throw new ArgumentOutOfRangeException(Number.ToString()),
            };
        }

        protected virtual string ConvertRange()
        {
            var converter = Factory.GetConverter(Number % RangeFrom);

            return $"{ConvertRangeFrom()} {converter.Convert()}";
        }

        protected abstract string ConvertRangeFrom();
    }
}
