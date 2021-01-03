using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero0To10Converter : NumeroConverter
    {
        public Numero0To10Converter(int number) : base(number)
        {
        }

        public override bool CanConvert()
        {
            return Number >= 0 && Number <= 10;
        }

        public override string Convert()
        {
            switch (Number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "jeden";
                case 2:
                    return "dwa";
                case 3:
                    return "trzy";
                case 4:
                    return "cztery";
                case 5:
                    return "pięć";
                case 6:
                    return "sześć";
                case 7:
                    return "siedem";
                case 8:
                    return "osiem";
                case 9:
                    return "dziewięć";
                case 10:
                    return "dziesięć";
                default:
                    throw new ArgumentOutOfRangeException(Number.ToString());
            }
        }
    }
}
