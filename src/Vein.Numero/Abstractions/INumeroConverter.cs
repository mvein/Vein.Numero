namespace Vein.Numero.Abstractions
{
    public interface INumeroConverter
    {
        bool CanConvert();

        string Convert();
    }
}
