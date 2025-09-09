namespace CurrencyConverterApp
{
    public interface ICurrencyConverter
    {
        Money Convert(Money from, Currency to);
    }
}