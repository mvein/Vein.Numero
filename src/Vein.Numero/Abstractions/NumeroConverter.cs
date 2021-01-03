namespace Vein.Numero.Abstractions
{
    public abstract class NumeroConverter : INumeroConverter
    {
        protected int Number;

        protected NumeroConverter(int number)
        {
            Number = number;
        }

        public abstract bool CanConvert();


        public abstract string Convert();
    }
}
