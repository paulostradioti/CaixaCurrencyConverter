using CurrencyConverterApp;

namespace CurrencyConverterMsTest
{
    public class BaseTestClass
    {
        public static class Converter
        {
            public static IRateProvider FakeRateProvider { get; }

            static Converter()
            {
                var rates = new Dictionary<(Currency From, Currency To), decimal> {
                { (Currency.USD, Currency.BRL), 5.48m },
                { (Currency.BRL, Currency.USD), 0.1852m },
                { (Currency.GBP, Currency.EUR), 1.16m },
                { (Currency.EUR, Currency.GBP), 0.8620689655172414m },
            };

                FakeRateProvider = new RateProvider(rates);
            }
        }
    }
}