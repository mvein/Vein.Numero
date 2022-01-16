﻿using System;
using Vein.Numero.Abstractions;

namespace Vein.Numero.Converters
{
    public class Numero100To199Converter : NumeroX00ToX99Converter
    {
        private readonly IConverterFactory _factory;

        public Numero100To199Converter(int number, IConverterFactory factory)
            : base(number, 100, 199)
        {
            _factory = factory;
        }

        protected override string ConvertRange(int number)
        {
            var converter = _factory.GetConverter(number % 100);

            return $"{ConvertRangeFrom()} {converter.Convert()}";
        }

        protected override string ConvertRangeFrom()
        {
            return Consts.Number._100;
        }
    }
}
