using CurrencyConverterApp;

namespace CurrencyConverterNUnit;

public class RateProviderUnitTests
{
    [Test]
    public void GivenExistingRate_WhenGettingRates_ShouldReturnCorrectAmount()
    {
        // Arrange
        var amount = 5.45m;
        var rates = new Dictionary<(Currency From, Currency To), decimal> { { (Currency.USD, Currency.BRL), amount } };
        var sut = new RateProvider(rates);

        // Act
        var result = sut.GetRate(Currency.USD, Currency.BRL);

        // Assert
        Assert.That(result, Is.EqualTo(amount));
    }

    [Test]
    public void GivenUnexistingRate_WhenGettingRates_ShouldThrowException()
    {
        var sut = new RateProvider(new() { });

        Assert.Throws<InvalidOperationException>(() => sut.GetRate(Currency.AED, Currency.BAM));
    }
}
