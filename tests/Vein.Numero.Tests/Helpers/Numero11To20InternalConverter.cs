namespace Vein.Numero.Tests.Helpers
{
    internal class Numero11To20InternalConverter : NumeroInternalConverter
    {
        public Numero11To20InternalConverter(int number)
            : base(number)
        {
        }

        protected override bool TryConvert(out string numero)
        {
#if NETCOREAPP3_1
            numero = Number switch
            {
                11 => NumeroHelper.Number._11,
                12 => NumeroHelper.Number._12,
                13 => NumeroHelper.Number._13,
                14 => Consts.Number._14,
                15 => Consts.Number._15,
                16 => Consts.Number._16,
                17 => NumeroHelper.Number._17,
                18 => NumeroHelper.Number._18,
                19 => Consts.Number._19,
                20 => NumeroHelper.Number._20,
                _ => null,
            };
#else
            switch (Number)
            {
                case 11:
                    numero = NumeroHelper.Number._11;
                    break;
                case 12:
                    numero = NumeroHelper.Number._12;
                    break;
                case 13:
                    numero = NumeroHelper.Number._13;
                    break;
                case 14:
                    numero = Consts.Number._14;
                    break;
                case 15:
                    numero = Consts.Number._15;
                    break;
                case 16:
                    numero = Consts.Number._16;
                    break;
                case 17:
                    numero = NumeroHelper.Number._17;
                    break;
                case 18:
                    numero = NumeroHelper.Number._18;
                    break;
                case 19:
                    numero = Consts.Number._19;
                    break;
                case 20:
                    numero = NumeroHelper.Number._20;
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