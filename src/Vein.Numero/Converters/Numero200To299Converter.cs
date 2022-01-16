using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero200To299Converter : NumeroX00ToX99Converter
    {
        public Numero200To299Converter(int number, IConverterFactory factory)
            : base(number, 200, 299, factory)
        {
        }

        protected override string ConvertRangeFrom()
        {
            return Consts.Number._200;
        }
    }
}
