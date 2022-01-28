using System;

public class UserShoppingCart
{
   public string DesiredCar { get; set; }
   public string DesiredCarColor { get; set; }
   public float DownPayment { get; set; }
   public bool IsLeasing { get; set; }
   public DateTime DateOfPickUp { get; set; }

   public override string ToString()
   {
      return string.Format("[UserShoppingCart DesiredCar={0}, DesiredCarColor={1}, DownPayment={2}, IsLeasing={3}, DateOfPickUp={4}]", DesiredCar, DesiredCarColor, DownPayment, IsLeasing, DateOfPickUp);
   }
}