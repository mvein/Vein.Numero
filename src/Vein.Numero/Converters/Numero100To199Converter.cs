using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero100To199Converter : NumeroX00ToX99Converter
    {
        public Numero100To199Converter(int number, IConverterFactory factory)
            : base(number, 100, 199, factory)
        {
        }

        protected override string ConvertRangeFrom()
        {
            return Consts.Number._100;
        }
    }
}
