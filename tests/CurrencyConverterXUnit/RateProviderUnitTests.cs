using CurrencyConverterApp;

namespace CurrencyConverterXUnit;

public class RateProviderUnitTests
{
    [Fact]
    public void GivenExistingRate_WhenGettingRates_ShouldReturnCorrectAmount()
    {
        // Arrange
        var amount = 5.45m;
        var rates = new Dictionary<(Currency From, Currency To), decimal> { { (Currency.USD, Currency.BRL), amount } };
        var sut = new RateProvider(rates);

        // Act
        var result = sut.GetRate(Currency.USD, Currency.BRL);

        // Assert
        Assert.Equal(result, amount);
    }

    [Fact]
    public void GivenUnexistingRate_WhenGettingRates_ShouldThrowException()
    {
        var sut = new RateProvider(new() { });

        Assert.Throws<InvalidOperationException>(() => sut.GetRate(Currency.AED, Currency.BAM));
    }
}
