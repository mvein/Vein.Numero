using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Tests.Helpers
{
    internal class NumeroInternalConverterFactory
    {
        public static INumeroConverter Create(int number)
        {
            INumeroConverter result = null;
#if NETCOREAPP3_1
            result = number switch
            {
                _ when number >= 1 && number <= 10 => new Numero1To10InternalConverter(number),
                _ when number > 10 && number <= 20 => new Numero11To20InternalConverter(number),
                _ when number > 20 && number <= 99 => new Numero21To99InternalConverter(number),
                _ => null,
            };
#else
            if (number >= 1 && number <= 10)
            {
                return new Numero1To10InternalConverter(number);
            }

            if (number > 10 && number <= 20)
            {
                return new Numero11To20InternalConverter(number);
            }

            if (number > 20 && number <= 99)
            {
                return new Numero21To99InternalConverter(number);
            }
#endif
            return result ?? throw new ArgumentOutOfRangeException($"Cannot find converter to for number: '{number}'.");
        }
    }
}