/// <summary>
/// Сводное описание для CarLotInfo
/// </summary>
public class CarLotInfo
{
   public string SalesPersonOfTheMonth { get; set; }
   public string CurrentCarOnSale { get; set; }
   public string MostPopularColorOnLot { get; set; }

   public CarLotInfo(string salesPersonOfTheMonth, string currentCarOnSale, string mostPopularColorOnLot)
   {
      SalesPersonOfTheMonth = salesPersonOfTheMonth;
      CurrentCarOnSale = currentCarOnSale;
      MostPopularColorOnLot = mostPopularColorOnLot;
   }
}