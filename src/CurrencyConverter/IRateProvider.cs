namespace CurrencyConverterApp
{
    public interface IRateProvider
    {
        //void AddRate(Currency from, Currency to, decimal amount);
        decimal GetRate(Currency from, Currency to);
    }
}