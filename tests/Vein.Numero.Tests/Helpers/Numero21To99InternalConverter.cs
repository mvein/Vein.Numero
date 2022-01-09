namespace Vein.Numero.Tests.Helpers
{
    internal class Numero21To99InternalConverter : NumeroInternalConverter
    {
        public Numero21To99InternalConverter(int number)
            : base(number)
        {
        }

        protected override bool TryConvert(out string numero)
        {
#if NETCOREAPP3_1
            numero = Number switch
            {
                21 => NumeroHelper.Number._21,
                22 => NumeroHelper.Number._22,
                23 => NumeroHelper.Number._23,
                24 => NumeroHelper.Number._24,
                25 => NumeroHelper.Number._25,
                26 => NumeroHelper.Number._26,
                27 => NumeroHelper.Number._27,
                28 => NumeroHelper.Number._28,
                29 => NumeroHelper.Number._29,
                30 => NumeroHelper.Number._30,
                41 => NumeroHelper.Number._41,
                42 => NumeroHelper.Number._42,
                43 => NumeroHelper.Number._43,
                44 => NumeroHelper.Number._44,
                45 => NumeroHelper.Number._45,
                46 => NumeroHelper.Number._46,
                47 => NumeroHelper.Number._47,
                48 => NumeroHelper.Number._48,
                49 => NumeroHelper.Number._49,
                50 => NumeroHelper.Number._50,
                51 => NumeroHelper.Number._51,
                52 => NumeroHelper.Number._52,
                53 => NumeroHelper.Number._53,
                54 => NumeroHelper.Number._54,
                55 => NumeroHelper.Number._55,
                56 => NumeroHelper.Number._56,
                57 => NumeroHelper.Number._57,
                58 => NumeroHelper.Number._58,
                59 => NumeroHelper.Number._59,
                60 => NumeroHelper.Number._60,
                61 => NumeroHelper.Number._61,
                62 => NumeroHelper.Number._62,
                63 => NumeroHelper.Number._63,
                64 => NumeroHelper.Number._64,
                65 => NumeroHelper.Number._65,
                66 => NumeroHelper.Number._66,
                67 => NumeroHelper.Number._67,
                68 => NumeroHelper.Number._68,
                69 => NumeroHelper.Number._69,
                70 => NumeroHelper.Number._70,
                71 => NumeroHelper.Number._71,
                72 => NumeroHelper.Number._72,
                73 => NumeroHelper.Number._73,
                74 => NumeroHelper.Number._74,
                75 => NumeroHelper.Number._75,
                76 => NumeroHelper.Number._76,
                77 => NumeroHelper.Number._77,
                78 => NumeroHelper.Number._78,
                79 => NumeroHelper.Number._79,
                80 => NumeroHelper.Number._80,
                81 => NumeroHelper.Number._81,
                82 => NumeroHelper.Number._82,
                83 => NumeroHelper.Number._83,
                84 => NumeroHelper.Number._84,
                85 => NumeroHelper.Number._85,
                86 => NumeroHelper.Number._86,
                87 => NumeroHelper.Number._87,
                88 => NumeroHelper.Number._88,
                89 => NumeroHelper.Number._89,
                90 => NumeroHelper.Number._90,
                91 => NumeroHelper.Number._91,
                92 => NumeroHelper.Number._92,
                93 => NumeroHelper.Number._93,
                94 => NumeroHelper.Number._94,
                95 => NumeroHelper.Number._95,
                96 => NumeroHelper.Number._96,
                97 => NumeroHelper.Number._97,
                98 => NumeroHelper.Number._98,
                99 => NumeroHelper.Number._99,
                _ => null,
            };
#else
            switch (Number)
            {
                case 21:
                    numero = NumeroHelper.Number._21;
                    break;
                case 22:
                    numero = NumeroHelper.Number._22;
                    break;
                case 23:
                    numero = NumeroHelper.Number._23;
                    break;
                case 24:
                    numero = NumeroHelper.Number._24;
                    break;
                case 25:
                    numero = NumeroHelper.Number._25;
                    break;
                case 26:
                    numero = NumeroHelper.Number._26;
                    break;
                case 27:
                    numero = NumeroHelper.Number._27;
                    break;
                case 28:
                    numero = NumeroHelper.Number._28;
                    break;
                case 29:
                    numero = NumeroHelper.Number._29;
                    break;
                case 30:
                    numero = NumeroHelper.Number._30;
                    break;
                case 31:
                    numero = NumeroHelper.Number._31;
                    break;
                case 32:
                    numero = NumeroHelper.Number._32;
                    break;
                case 33:
                    numero = NumeroHelper.Number._33;
                    break;
                case 34:
                    numero = NumeroHelper.Number._34;
                    break;
                case 35:
                    numero = NumeroHelper.Number._35;
                    break;
                case 36:
                    numero = NumeroHelper.Number._36;
                    break;
                case 37:
                    numero = NumeroHelper.Number._37;
                    break;
                case 38:
                    numero = NumeroHelper.Number._38;
                    break;
                case 39:
                    numero = NumeroHelper.Number._39;
                    break;
                case 40:
                    numero = NumeroHelper.Number._40;
                    break;
                case 41:
                    numero = NumeroHelper.Number._41;
                    break;
                case 42:
                    numero = NumeroHelper.Number._42;
                    break;
                case 43:
                    numero = NumeroHelper.Number._43;
                    break;
                case 44:
                    numero = NumeroHelper.Number._44;
                    break;
                case 45:
                    numero = NumeroHelper.Number._45;
                    break;
                case 46:
                    numero = NumeroHelper.Number._46;
                    break;
                case 47:
                    numero = NumeroHelper.Number._47;
                    break;
                case 48:
                    numero = NumeroHelper.Number._48;
                    break;
                case 49:
                    numero = NumeroHelper.Number._49;
                    break;
                case 50:
                    numero = NumeroHelper.Number._50;
                    break;
                case 51:
                    numero = NumeroHelper.Number._51;
                    break;
                case 52:
                    numero = NumeroHelper.Number._52;
                    break;
                case 53:
                    numero = NumeroHelper.Number._53;
                    break;
                case 54:
                    numero = NumeroHelper.Number._54;
                    break;
                case 55:
                    numero = NumeroHelper.Number._55;
                    break;
                case 56:
                    numero = NumeroHelper.Number._56;
                    break;
                case 57:
                    numero = NumeroHelper.Number._57;
                    break;
                case 58:
                    numero = NumeroHelper.Number._58;
                    break;
                case 59:
                    numero = NumeroHelper.Number._59;
                    break;
                case 60:
                    numero = NumeroHelper.Number._60;
                    break;
                case 61:
                    numero = NumeroHelper.Number._61;
                    break;
                case 62:
                    numero = NumeroHelper.Number._62;
                    break;
                case 63:
                    numero = NumeroHelper.Number._63;
                    break;
                case 64:
                    numero = NumeroHelper.Number._64;
                    break;
                case 65:
                    numero = NumeroHelper.Number._65;
                    break;
                case 66:
                    numero = NumeroHelper.Number._66;
                    break;
                case 67:
                    numero = NumeroHelper.Number._67;
                    break;
                case 68:
                    numero = NumeroHelper.Number._68;
                    break;
                case 69:
                    numero = NumeroHelper.Number._69;
                    break;
                case 70:
                    numero = NumeroHelper.Number._70;
                    break;
                case 71:
                    numero = NumeroHelper.Number._71;
                    break;
                case 72:
                    numero = NumeroHelper.Number._72;
                    break;
                case 73:
                    numero = NumeroHelper.Number._73;
                    break;
                case 74:
                    numero = NumeroHelper.Number._74;
                    break;
                case 75:
                    numero = NumeroHelper.Number._75;
                    break;
                case 76:
                    numero = NumeroHelper.Number._76;
                    break;
                case 77:
                    numero = NumeroHelper.Number._77;
                    break;
                case 78:
                    numero = NumeroHelper.Number._78;
                    break;
                case 79:
                    numero = NumeroHelper.Number._79;
                    break;
                case 80:
                    numero = NumeroHelper.Number._80;
                    break;
                case 81:
                    numero = NumeroHelper.Number._81;
                    break;
                case 82:
                    numero = NumeroHelper.Number._82;
                    break;
                case 83:
                    numero = NumeroHelper.Number._83;
                    break;
                case 84:
                    numero = NumeroHelper.Number._84;
                    break;
                case 85:
                    numero = NumeroHelper.Number._85;
                    break;
                case 86:
                    numero = NumeroHelper.Number._86;
                    break;
                case 87:
                    numero = NumeroHelper.Number._87;
                    break;
                case 88:
                    numero = NumeroHelper.Number._88;
                    break;
                case 89:
                    numero = NumeroHelper.Number._89;
                    break;
                case 90:
                    numero = NumeroHelper.Number._90;
                    break;
                case 91:
                    numero = NumeroHelper.Number._91;
                    break;
                case 92:
                    numero = NumeroHelper.Number._92;
                    break;
                case 93:
                    numero = NumeroHelper.Number._93;
                    break;
                case 94:
                    numero = NumeroHelper.Number._94;
                    break;
                case 95:
                    numero = NumeroHelper.Number._95;
                    break;
                case 96:
                    numero = NumeroHelper.Number._96;
                    break;
                case 97:
                    numero = NumeroHelper.Number._97;
                    break;
                case 98:
                    numero = NumeroHelper.Number._98;
                    break;
                case 99:
                    numero = NumeroHelper.Number._99;
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