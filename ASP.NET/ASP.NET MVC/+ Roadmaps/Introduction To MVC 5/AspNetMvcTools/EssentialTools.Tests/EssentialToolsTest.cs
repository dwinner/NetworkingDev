using System;
using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialTools.Tests
{
   [TestClass]
   public class EssentialToolsTest
   {
      private static IDiscountHelper GetTestObject()
      {
         return new MinimumDiscountHelper();
      }

      [TestMethod]
      public void DiscountAbove100()
      {
         // Организация
         var target = GetTestObject();
         const decimal total = 200;

         // Действие
         var discountedTotal = target.ApplyDiscount(total);

         // Утверждение
         Assert.AreEqual(total * 0.9M, discountedTotal);
      }

      [TestMethod]
      public void DiscountBetween10And100()
      {
         // Организация
         var target = GetTestObject();

         // Действие
         var tenDollarDiscount = target.ApplyDiscount(10);
         var hundredDollarDiscount = target.ApplyDiscount(100);
         var fiftyDollarDiscount = target.ApplyDiscount(50);

         // Утверждение
         Assert.AreEqual(5, tenDollarDiscount, "$10 discount is wrong");
         Assert.AreEqual(95, hundredDollarDiscount, "$100 discount is wrong");
         Assert.AreEqual(45, fiftyDollarDiscount, "$50 discount is wrong");
      }

      [TestMethod]
      public void DiscountLessThan10()
      {
         // Организация
         var discountHelper = GetTestObject();

         // Действие
         var discount5 = discountHelper.ApplyDiscount(5);
         var discount0 = discountHelper.ApplyDiscount(0);

         // Утверждение
         Assert.AreEqual(5, discount5);
         Assert.AreEqual(0, discount0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void DiscountNegativeTotal()
      {
         // Организация
         var target = GetTestObject();

         // Действие
         target.ApplyDiscount(-1);
      }
   }
}