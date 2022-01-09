using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero100To199Converter : NumeroConverter
    {
        private readonly IConverterFactory _factory;

        public Numero100To199Converter(int number, IConverterFactory factory) : base(number)
        {
            _factory = factory;
        }

        public override bool CanConvert()
        {
            return Number >= 100 && Number <= 199;
        }

        public override string Convert()
        {
            return Number switch
            {
                100 => Convert100(),                
                _ when Number > 100 && Number < 200 => Convert101To199(Number),
                _ => throw new ArgumentOutOfRangeException(Number.ToString()),
            };
        }

        private string Convert101To199(int number)
        {
            var converter = _factory.GetConverter(number % 100);

            return $"{Convert100()} {converter.Convert()}";
        }

        private string Convert100()
        {
            return Consts.Number._100;
        }
    }
}
