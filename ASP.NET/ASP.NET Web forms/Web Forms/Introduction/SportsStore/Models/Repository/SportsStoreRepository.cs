using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace SportsStore.Models.Repository
{
   /// <summary>
   /// Шлюз между бизнес-логикой и базой данных
   /// </summary>
   public class SportsStoreRepository
   {
      private readonly SportsStoreDatabaseContext _context = new SportsStoreDatabaseContext();

      /// <summary>
      /// Список продуктов
      /// </summary>
      public IEnumerable<Product> Products
      {
         get { return _context.Products; }
      }

      /// <summary>
      /// Список заказов
      /// </summary>
      public IEnumerable<Order> Orders
      {
         get { return _context.Orders.Include(order => order.OrderLines.Select(line => line.Product)); }
      }

      /// <summary>
      /// Вставка нового или обновление существующего заказа
      /// </summary>
      /// <param name="anOrder">Заказ</param>
      /// <returns>Кол-во сохраненных сущностей</returns>
      public int Save(Order anOrder)
      {
         if (anOrder.OrderId == 0)
         {
            Order newOrder = _context.Orders.Add(anOrder);
            foreach (var line in newOrder.OrderLines)
            {
               _context.Entry(line.Product).State = EntityState.Modified;
            }
         }
         else
         {
            Order dbOrder = _context.Orders.Find(anOrder.OrderId);
            if (dbOrder != null)
            {
               dbOrder.Name = anOrder.Name;
               dbOrder.Line1 = anOrder.Line1;
               dbOrder.Line2 = anOrder.Line2;
               dbOrder.Line3 = anOrder.Line3;
               dbOrder.City = anOrder.City;
               dbOrder.State = anOrder.State;
               dbOrder.GiftWrap = anOrder.GiftWrap;
               dbOrder.Dispatched = anOrder.Dispatched;
            }
         }

         return _context.SaveChanges();
      }

      /// <summary>
      /// Вставка нового или обновление существующего продукта
      /// </summary>
      /// <param name="aProduct">Продукт</param>
      /// <returns>Кол-во сохраненных сущностей</returns>
      public int Save(Product aProduct)
      {
         if (aProduct.ProductId == 0)
         {
            _context.Products.Add(aProduct);
         }
         else
         {
            Product foundProduct = _context.Products.Find(aProduct.ProductId);
            if (foundProduct != null)
            {
               foundProduct.Name = aProduct.Name;
               foundProduct.Description = aProduct.Description;
               foundProduct.Price = aProduct.Price;
               foundProduct.Category = aProduct.Category;
            }
         }

         return _context.SaveChanges();
      }

      /// <summary>
      /// Удаление продукта
      /// </summary>
      /// <param name="aProduct">Продукт для удаления</param>
      /// <returns>Кол-во удаленных сущностей</returns>
      public int Delete(Product aProduct)
      {
         IEnumerable<Order> orders =
            _context.Orders.Include(order => order.OrderLines.Select(line => line.Product))
               .Where(order => order.OrderLines.Count(line => line.Product.ProductId == aProduct.ProductId) > 0)
               .ToArray();
         foreach (var order in orders)
         {
            _context.Orders.Remove(order);
         }

         _context.Products.Remove(aProduct);
         
         return _context.SaveChanges();
      }
   }
}