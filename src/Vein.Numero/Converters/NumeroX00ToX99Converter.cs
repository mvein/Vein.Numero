using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public abstract class NumeroX00ToX99Converter : NumeroConverter
    {
        private readonly int _rangeFrom;
        private readonly int _rangeTo;

        protected NumeroX00ToX99Converter(
            int number,
            int rangeFrom,
            int rangeTo) : base(number)
        {
            _rangeFrom = rangeFrom;
            _rangeTo = rangeTo;
        }

        public override bool CanConvert()
        {
            return Number >= _rangeFrom && Number <= _rangeTo;
        }

        public override string Convert()
        {
            return Number switch
            {
                _ when Number == _rangeFrom => ConvertRangeFrom(),
                _ when Number > _rangeFrom && Number <= _rangeTo => ConvertRange(Number),
                _ => throw new ArgumentOutOfRangeException(Number.ToString()),
            };
        }

        protected abstract string ConvertRange(int number);

        protected abstract string ConvertRangeFrom();
    }
}
