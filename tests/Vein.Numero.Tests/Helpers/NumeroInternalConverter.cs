using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Tests.Helpers
{
    internal abstract class NumeroInternalConverter : INumeroConverter
    {
        protected readonly int Number;

        protected NumeroInternalConverter(int number)
        {
            Number = number;
        }

        public bool CanConvert()
        {
            throw new NotImplementedException();
        }

        public string Convert()
        {
            if (TryConvert(out var result))
            {
                return result;
            }

            throw new ArgumentOutOfRangeException(Number.ToString());
        }

        protected abstract bool TryConvert(out string numero);
    }
}
