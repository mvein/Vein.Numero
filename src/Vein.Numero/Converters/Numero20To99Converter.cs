using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero20To99Converter : NumeroConverter
    {
        private readonly IConverterFactory _factory;

        public Numero20To99Converter(int number, IConverterFactory factory) : base(number)
        {
            _factory = factory;
        }

        public override bool CanConvert()
        {
            return Number >= 20 && Number <= 99;
        }

        public override string Convert()
        {
            return Number switch
            {
                20 => Convert20(),                
                _ when Number > 20 && Number < 30 => Convert21To29(Number),
                30 => Convert30(),
                _ when Number > 30 && Number < 40 => Convert31To39(Number),
                40 => Convert40(),
                _ when Number > 40 && Number < 50 => Convert41To49(Number),
                50 => Convert5060708090(5),
                _ when Number > 50 && Number < 60 => Convert51To59(Number),
                60 => Convert5060708090(6),
                _ when Number > 60 && Number < 70 => Convert61To69(Number),
                70 => Convert5060708090(7),
                _ when Number > 70 && Number < 80 => Convert71To79(Number),
                80 => Convert5060708090(8),
                _ when Number > 80 && Number < 90 => Convert81To89(Number),
                90 => Convert5060708090(9),
                _ when Number > 90 && Number < 100 => Convert91To99(Number),
                _ => throw new ArgumentOutOfRangeException(Number.ToString()),
            };
        }

        private string Convert21To29(int number)
        {
            var converter = _factory.GetConverter(number % 20);

            return $"{Convert20()} {converter.Convert()}";
        }

        private string Convert31To39(int number)
        {
            var converter = _factory.GetConverter(number % 30);

            return $"{Convert30()} {converter.Convert()}";
        }

        private string Convert41To49(int number)
        {
            var converter = _factory.GetConverter(number % 40);

            return $"{Convert40()} {converter.Convert()}";
        }

        private string Convert51To59(int number)
        {
            var converter = _factory.GetConverter(number % 50);

            return $"{Convert5060708090(5)} {converter.Convert()}";
        }

        private string Convert61To69(int number)
        {
            var converter = _factory.GetConverter(number % 60);

            return $"{Convert5060708090(6)} {converter.Convert()}";
        }

        private string Convert71To79(int number)
        {
            var converter = _factory.GetConverter(number % 70);

            return $"{Convert5060708090(7)} {converter.Convert()}";
        }

        private string Convert81To89(int number)
        {
            var converter = _factory.GetConverter(number % 80);

            return $"{Convert5060708090(8)} {converter.Convert()}";
        }

        private string Convert91To99(int number)
        {
            var converter = _factory.GetConverter(number % 90);

            return $"{Convert5060708090(9)} {converter.Convert()}";
        }

        private string Convert20()
        {
            var converter = _factory.GetConverter(2);
            return $"{converter.Convert()}dzieścia";
        }

        private string Convert30()
        {
            var converter = _factory.GetConverter(3);
            return $"{converter.Convert()}dzieści";
        }

        private string Convert40()
        {
            return Consts.Number._40;
        }

        private string Convert5060708090(int number)
        {
            var converter = _factory.GetConverter(number);
            return $"{converter.Convert()}dziesiąt";
        }
    }
}
