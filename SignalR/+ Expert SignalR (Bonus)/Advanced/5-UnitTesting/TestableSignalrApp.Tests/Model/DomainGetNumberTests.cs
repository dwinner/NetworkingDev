using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestableSignalrApp.Model;

namespace TestableSignalrApp.Tests.Model
{
    [TestClass]
    public class DomainGetNumberTests
    {
        [TestMethod]
        public void GetNumber_Returns_10xA_if_A_is_greater_than_10()
        {
            // Arrange
            var mock = new Mock<ICalculator>();
            mock.Setup(c => c.Multiply(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int a, int b) => a * b);

            var fakeCalculator = mock.Object;

            var domain = new Domain(fakeCalculator);
            var value = 12;
            var expected = 120;

            // Act
            var result = domain.GetNumber(value);

            // Assert
            Assert.AreEqual(expected, result);
            mock.Verify(calc => calc.Multiply(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }


        [TestMethod]
        public void GetNumber_Returns_Minus_A_if_A_is_less_than_5()
        {
            // Arrange
            var mock = new Mock<ICalculator>();
            mock.Setup(c => c.Multiply(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int a, int b) => a * b);

            var fakeCalculator = mock.Object;

            var domain = new Domain(fakeCalculator);
            var value = 4;
            var expected = -4;

            // Act
            var result = domain.GetNumber(value);

            // Assert
            Assert.AreEqual(expected, result);
            mock.Verify(calc => calc.Multiply(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void GetNumber_Returns_2xA_If_A_Is_In_Range_5_To_10()
        {
            // Arrange
            var mock = new Mock<ICalculator>();
            mock.Setup(c => c.Multiply(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int a, int b) => a * b);
            var fakeCalculator = mock.Object;

            var domain = new Domain(fakeCalculator);
            var value = 5;
            var expected = 10;

            // Act
            var result = domain.GetNumber(value);

            // Assert
            Assert.AreEqual(expected, result);
            mock.Verify(calc => calc.Multiply(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
    }
}
