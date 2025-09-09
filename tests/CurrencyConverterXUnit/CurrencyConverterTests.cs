using CurrencyConverterApp;
using System.Drawing;

namespace CurrencyConverterMsTest
{
    // TAREFA
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)

    public class CurrencyConverterTests : BaseTestClass
    {
        [Fact]
        public void GivenSameCurrency_WhenConverting_ThenReturnsSameAmount()
        {
            // Arrange
            var converter = new CurrencyConverter(FakeRateProvider);
            var original = new Money(100, Currency.USD);

            // Act
            var actual = converter.Convert(original, Currency.USD);

            //Assert

            // Opção 1 - Aproveitar o fato de Money ser um tipo por Valor
            Assert.Equal(original, actual);

            // Opção 2 - Mais de um Assert
            Assert.Equal(original.Amount, actual.Amount);
            Assert.Equal(original.Currency, actual.Currency);
        }

        [Fact]
        public void GivenKnownConversion_WhenConverting_ThenPrecisionIsCorrect()
        {
            // Arrange
            var converter = new CurrencyConverter(FakeRateProvider);
            var original = new Money(2.52m, Currency.BRL);

            // Taxa:      0.1852m 
            // Amount:    2.52
            // Resultado: 0.466704

            // Act
            var actual = converter.Convert(original, Currency.USD);
            var delta = 0.0001m;

            //Assert
            Assert.Equal(0.467m, actual.Amount, precision: 3); // 0.4667m -> 0.467
            Assert.InRange(actual.Amount, actual.Amount - delta, actual.Amount + delta); // 👍
            Assert.True(Math.Abs(actual.Amount - 0.467m) <= delta); // 👎
        }

        [Fact]
        public void GivenKnownConversion_WhenConvertingAndUnconverting_ThenAmountShouldBeAboutTheSame()
        {
            // Arrange
            var converter = new CurrencyConverter(FakeRateProvider);

            var original = new Money(100m, Currency.GBP);
            var conversion = converter.Convert(original, Currency.EUR);
            var reversion = converter.Convert(conversion, Currency.GBP);

            //Assert
            Assert.Equal(100m, reversion.Amount, precision: 0);
        }
    }
}
