namespace CurrencyConverterApp
{
    public readonly struct Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
