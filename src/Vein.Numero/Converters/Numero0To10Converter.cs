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
            return Number switch
            {
                0 => Consts.Number._0,
                1 => Consts.Number._1,
                2 => Consts.Number._2,
                3 => Consts.Number._3,
                4 => Consts.Number._4,
                5 => Consts.Number._5,
                6 => Consts.Number._6,
                7 => Consts.Number._7,
                8 => Consts.Number._8,
                9 => Consts.Number._9,
                10 => Consts.Number._10,
                _ => throw new ArgumentOutOfRangeException(Number.ToString()),
            };
        }
    }
}
