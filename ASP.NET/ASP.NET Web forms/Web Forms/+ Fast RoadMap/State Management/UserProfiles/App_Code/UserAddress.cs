using System;

/// <summary>
/// Класс профиля UserAddress
/// </summary>
[Serializable]
public class UserAddress
{
   public string Street { get; set; }
   public string City { get; set; }
   public string State { get; set; }
}