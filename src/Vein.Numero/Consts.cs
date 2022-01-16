using System;

namespace Vein.Numero
{
    internal static class Consts
    {
        internal static class Number
        {
            internal const string _0 = "zero";
            internal const string _1 = "jeden";
            internal const string _2 = "dwa";
            internal const string _3 = "trzy";
            internal const string _4 = "cztery";
            internal const string _5 = "pięć";
            internal const string _6 = "sześć";
            internal const string _7 = "siedem";
            internal const string _8 = "osiem";
            internal const string _9 = "dziewięć";
            internal const string _10 = "dziesięć";            
            internal const string _14 = "czternaście";
            internal const string _15 = "piętnaście";
            internal const string _16 = "szesnaście";
            internal const string _19 = "dziewiętnaście";
            internal const string _40 = "czterdzieści";
            internal const string _100 = "sto";
            internal const string _200 = "dwieście";
            internal const string _300 = "trzysta";
            internal const string _400 = "czterysta";

            internal static string _500_900(int number)
            {
                return number switch
                {
                    5 => _500,
                    6 => _600,
                    7 => _700,
                    8 => _800,
                    9 => _900,
                    _ => throw new ArgumentOutOfRangeException(number.ToString()),
                };                    
            }

            internal const string _500 = "pięćset";
            internal const string _600 = "sześćset";
            internal const string _700 = "siedemset";
            internal const string _800 = "osiemset";
            internal const string _900 = "dziewięćset";

            internal const string _1000 = "tysiąc";
        }
    }
}
