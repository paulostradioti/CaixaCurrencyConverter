namespace CurrencyConverterApp
{
    public class RateProvider : IRateProvider
    {
        private readonly Dictionary<(Currency From, Currency To), decimal> rates;

        public RateProvider()
        {
            rates = new()
            {
                {(Currency.USD, Currency.BRL), 5.45m},
                {(Currency.BRL, Currency.USD), 0.18m},
                {(Currency.EUR, Currency.USD), 1.10m},
                {(Currency.CAD, Currency.USD), 1.35m},
            };
        }

        public RateProvider(Dictionary<(Currency From, Currency To), decimal> rates)
            => this.rates = rates;

        public decimal GetRate(Currency from, Currency to)
        {
            if (rates.TryGetValue((from, to), out var rate))
                return rate;

            throw new InvalidOperationException();
        }
    }
}
