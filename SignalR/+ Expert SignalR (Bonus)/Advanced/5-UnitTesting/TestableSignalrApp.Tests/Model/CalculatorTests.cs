using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestableSignalrApp.Model;

namespace TestableSignalrApp.Tests.Model
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Sum_Follows_The_Properties_Of_Addition()
        {
            // Arrange
            var calc =new  Calculator();
            
            // Act
            var itSums = calc.Sum(3, 5) == 8 && calc.Sum(-1, -3) == -4;
            var conmutative = calc.Sum(1, 2) == calc.Sum(2, 1);
            var associative = calc.Sum(1, calc.Sum(2, 3)) == calc.Sum(calc.Sum(1, 2), 3);
            var additiveIdentitity = calc.Sum(1, 0) == 1;
            var distributive = calc.Multiply(2, calc.Sum(1, 3)) == calc.Sum(calc.Multiply(2, 1), calc.Multiply(2, 3));

            //Assert
            Assert.IsTrue(itSums, "Addition");
            Assert.IsTrue(conmutative, "Conmutative");
            Assert.IsTrue(associative, "Associative");
            Assert.IsTrue(additiveIdentitity, "Additive identity");
            Assert.IsTrue(distributive, "Distributive");
        }

        [TestMethod]
        public void Multiply_Follows_The_Properties_Of_Multiplication()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var itMultiplies = calc.Multiply(3, 5) == 15 && calc.Multiply(-1, -3) == 3 && calc.Multiply(2, -1) == -2;
            var conmutative = calc.Multiply(3, 2) == calc.Multiply(2, 3);
            var associative = calc.Multiply(1, calc.Multiply(2, 3)) == calc.Multiply(calc.Multiply(1, 2), 3);
            var multiplicativeIdentitity = calc.Multiply(3, 1) == 3;
            var distributiveSum = calc.Multiply(2, calc.Sum(1, 3)) == calc.Sum(calc.Multiply(2, 1), calc.Multiply(2, 3));
            var distributiveSubstraction = calc.Multiply(2, calc.Substract(1, 3)) == calc.Substract(calc.Multiply(2, 1), calc.Multiply(2, 3));

            //Assert
            Assert.IsTrue(itMultiplies, "Multiplication");
            Assert.IsTrue(conmutative, "Conmutative");
            Assert.IsTrue(associative, "Associative");
            Assert.IsTrue(multiplicativeIdentitity, "Multiplicative identity");
            Assert.IsTrue(distributiveSum, "Distributive sum");
            Assert.IsTrue(distributiveSubstraction, "Distributive substraction");
        }

        [TestMethod]
        public void Divide_Follows_The_Properties_Of_Division()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var itDivides = calc.Divide(6, 3) == 2 && calc.Divide(-10, -5) == 2 && calc.Divide(15, -3) == -5;
            var divisiveIdentitity = calc.Divide(3, 1) == 3;
            var zeroDivision = calc.Divide(0, 3) == 0;
            var conmutative = calc.Divide(10, 5) == calc.Divide(5, 10);
            var associative = calc.Divide(16, calc.Divide(8, 4)) == calc.Divide(calc.Multiply(16, 8), 4);
            int? divisionByZero = null;
            try
            {
                divisionByZero = calc.Divide(3, 0);
            }
            catch {}


            //Assert
            Assert.IsTrue(itDivides, "Division");
            Assert.IsFalse(conmutative, "Conmutative");
            Assert.IsFalse(associative, "Associative");
            Assert.IsTrue(divisiveIdentitity, "Divisive identity");
            Assert.IsTrue(zeroDivision, "Zero division");
            Assert.IsNull(divisionByZero, "Division by zero");
           
        }

        [TestMethod]
        public void Substract_Follows_The_Properties_Of_Substraction()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var itSubstracts = calc.Substract(3, 5) == -2 && calc.Substract(-1, -3) == 2 && calc.Substract(10, 3) == 7;
            var conmutative = calc.Substract(1, 2) == calc.Substract(2, 1);
            var associative = calc.Substract(1, calc.Substract(2, 3)) == calc.Substract(calc.Substract(1, 2), 3);
            var identity = calc.Substract(1, 0) == 1;
            var distributive = calc.Multiply(2, calc.Substract(1, 3)) == calc.Substract(calc.Multiply(2, 1),  calc.Multiply(2, 3));

            //Assert
            Assert.IsTrue(itSubstracts, "Substraction");
            Assert.IsFalse(conmutative, "Conmutative");
            Assert.IsFalse(associative, "Associative");
            Assert.IsTrue(identity, "Identity");
            Assert.IsTrue(distributive, "Distributive");
        }

    }
}
