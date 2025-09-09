using CurrencyConverterApp;

namespace CurrencyConverterMsTest
{
    // TAREFA
    // Testar Conversão A -> A
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)

    /*
     * 1 - Quantidade de Asserts por Teste
     * 2 - Precisão
     */

    [TestClass]
    public class CurrencyConverterTests : BaseTestClass
    {
        [TestMethod]
        public void GivenSameCurrency_WhenConverting_ThenReturnsSameAmount()
        {
            // Arrange
            var converter = new CurrencyConverter(FakeRateProvider);
            var original = new Money(100, Currency.USD);

            // Act
            var actual = converter.Convert(original, Currency.USD);

            //Assert

            // Opção 1 - Aproveitar o fato de Money ser um tipo por Valor
            Assert.AreEqual(original, actual);

            // Opção 2 - Mais de um Assert
            Assert.AreEqual(original.Amount, actual.Amount);
            Assert.AreEqual(original.Currency, actual.Currency);
        }

        [TestMethod]
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

            //Assert
            Assert.AreEqual(0.4667m, actual.Amount, 0.0001m);
        }

        [TestMethod]
        public void GivenKnownConversion_WhenConvertingAndUnconverting_ThenAmountShouldBeAboutTheSame()
        {
            // Arrange
            var converter = new CurrencyConverter(FakeRateProvider);
            
            var original = new Money(100m, Currency.GBP);
            var conversion = converter.Convert(original, Currency.EUR);
            var reversion = converter.Convert(conversion, Currency.GBP);

            //Assert
            Assert.AreEqual(100m, reversion.Amount, 0.00000000001m);
        }
    }
}