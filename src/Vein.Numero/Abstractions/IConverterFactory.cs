namespace Vein.Numero.Abstractions
{
    public interface IConverterFactory
    {
        INumeroConverter GetConverter(int number);
    }
}
