using CurrencyConverterApp;

namespace CurrencyConverterMsTest
{
    // TAREFA
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)

    public class CurrencyConverterTests : BaseTestClass
    {
        [Test]
        public void GivenSameCurrency_WhenConverting_ThenReturnsSameAmount()
        {
            // Arrange
            var converter = new CurrencyConverter(Converter.FakeRateProvider);
            var original = new Money(100, Currency.USD);

            // Act
            var actual = converter.Convert(original, Currency.USD);

            //Assert

            // Opção 1 - Aproveitar o fato de Money ser um tipo por Valor
            Assert.That(actual, Is.EqualTo(original));

            // Opção 2 - Mais de um Assert
            Assert.That(original.Amount, Is.EqualTo(actual.Amount));
            Assert.That(original.Currency, Is.EqualTo(actual.Currency));
        }

        [Test]
        public void GivenKnownConversion_WhenConverting_ThenPrecisionIsCorrect()
        {
            // Arrange
            var converter = new CurrencyConverter(Converter.FakeRateProvider);
            var original = new Money(2.52m, Currency.BRL);

            // Taxa:      0.1852m 
            // Amount:    2.52
            // Resultado: 0.466704

            // Act
            var actual = converter.Convert(original, Currency.USD);

            //Assert
            Assert.That(actual.Amount, Is.EqualTo(0.4667m).Within(0.0001m));
            Assert.That(actual.Amount, Is.EqualTo(0.4667m).Within(0.01).Percent);
        }

        [Test]
        public void GivenKnownConversion_WhenConvertingAndUnconverting_ThenAmountShouldBeAboutTheSame()
        {
            // Arrange
            var converter = new CurrencyConverter(Converter.FakeRateProvider);

            var original = new Money(100m, Currency.GBP);
            var conversion = converter.Convert(original, Currency.EUR);
            var reversion = converter.Convert(conversion, Currency.GBP);

            //Assert
            Assert.That(reversion.Amount, Is.EqualTo(original.Amount).Within(0.0001m));
        }
    }
}
