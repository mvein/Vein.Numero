namespace Vein.Numero.Tests.Helpers
{
    internal class Numero1To10InternalConverter : NumeroInternalConverter
    {
        public Numero1To10InternalConverter(int number)
            : base(number)
        {
        }

        protected override bool TryConvert(out string numero)
        {
#if NETCOREAPP3_1
            numero = Number switch
            {
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
                _ => null,
            };
#else
            switch (Number)
            {
                case 1:
                    numero = Consts.Number._1;
                    break;
                case 2:
                    numero = Consts.Number._2;
                    break;
                case 3:
                    numero = Consts.Number._3;
                    break;
                case 4:
                    numero = Consts.Number._4;
                    break;
                case 5:
                    numero = Consts.Number._5;
                    break;
                case 6:
                    numero = Consts.Number._6;
                    break;
                case 7:
                    numero = Consts.Number._7;
                    break;
                case 8:
                    numero = Consts.Number._8;
                    break;
                case 9:
                    numero = Consts.Number._9;
                    break;
                case 10:
                    numero = Consts.Number._10;
                    break;
                default:
                    numero = null;
                    break;
            };
#endif
            return !string.IsNullOrEmpty(numero);
        }
    }
}