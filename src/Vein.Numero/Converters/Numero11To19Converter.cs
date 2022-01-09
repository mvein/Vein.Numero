using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero11To19Converter : NumeroConverter
    {
        private readonly IConverterFactory _factory;

        public Numero11To19Converter(int number, IConverterFactory factory) : base(number)
        {
            _factory = factory;
        }

        public override bool CanConvert()
        {
            return Number >= 11 && Number <= 19;
        }

        public override string Convert()
        {
            INumeroConverter converter;
            switch (Number)
            {
                case 11:
                    converter = _factory.GetConverter(1);
                    return $"{converter.Convert()}aście";
                case 12:
                    converter = _factory.GetConverter(2);
                    return $"{converter.Convert()}naście";
                case 13:
                    converter = _factory.GetConverter(3);
                    return $"{converter.Convert()}naście";
                case 14:
                    return Consts.Number._14;
                case 15:
                    return Consts.Number._15;
                case 16:
                    return Consts.Number._16;
                case 17:
                    converter = _factory.GetConverter(7);
                    return $"{converter.Convert()}naście";
                case 18:
                    converter = _factory.GetConverter(8);
                    return $"{converter.Convert()}naście";                    
                case 19:
                    return Consts.Number._19;
                default:
                    throw new ArgumentOutOfRangeException(Number.ToString());
            }
        }
    }
}
