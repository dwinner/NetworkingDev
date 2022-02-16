using System;
using System.Linq;
using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EssentialTools.Tests
{
   [TestClass]
   public class MoqUnitTest
   {
      private readonly Product[] _products =
      {
         new Product
         {
            Name = "Kayak",
            Category = "Watersports",
            Price = 275M
         },
         new Product
         {
            Name = "Lifejacket",
            Category = "Watersports",
            Price = 48.95M
         },
         new Product
         {
            Name = "Soccer ball",
            Category = "Soccer",
            Price = 19.50M
         },
         new Product
         {
            Name = "Corner flag",
            Category = "Soccer",
            Price = 34.95M
         }
      };

      private Product[] CreateProducts(decimal value)
      {
         return new[] { new Product { Price = value } };
      }

      [TestMethod]
      public void SumProductsCorrectly()
      {
         // Организация
         var mock = new Mock<IDiscountHelper>();
         mock.Setup(helper => helper.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
         IValueCalculator target = new LinqValueCalculator(mock.Object);

         // Действие
         var result = target.ValueProducts(_products);

         // Утверждение
         Assert.AreEqual(_products.Sum(product => product.Price), result);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void PassThroughVariableDiscounts()
      {
         // Организация
         var mock = new Mock<IDiscountHelper>();
         mock.Setup(helper => helper.ApplyDiscount(It.IsAny<decimal>()))
            .Returns<decimal>(total => total);
         mock.Setup(helper => helper.ApplyDiscount(It.Is<decimal>(arg => arg == 0)))
            .Throws<ArgumentOutOfRangeException>();
         mock.Setup(helper => helper.ApplyDiscount(It.Is<decimal>(arg => arg > 100)))
            .Returns<decimal>(arg => arg * 0.9M);
         mock.Setup(helper => helper.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
            .Returns<decimal>(arg => arg - 5);
         IValueCalculator target = new LinqValueCalculator(mock.Object);

         // Действие
         var fiveDollarDiscount = target.ValueProducts(CreateProducts(5));
         var tenDollarDiscount = target.ValueProducts(CreateProducts(10));
         var fiftyDollarDiscount = target.ValueProducts(CreateProducts(50));
         var hundredDollarDiscount = target.ValueProducts(CreateProducts(100));
         var fiveHundredDollarDiscount = target.ValueProducts(CreateProducts(500));

         // Утверждение
         Assert.AreEqual(5, fiveDollarDiscount, "$5 Fail");
         Assert.AreEqual(5, tenDollarDiscount, "$10 Fail");
         Assert.AreEqual(45, fiftyDollarDiscount, "$50 Fail");
         Assert.AreEqual(95, hundredDollarDiscount, "$100 Fail");
         Assert.AreEqual(450, fiveHundredDollarDiscount, "$500 Fail");
         target.ValueProducts(CreateProducts(0));
      }
   }
}