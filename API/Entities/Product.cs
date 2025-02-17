using System;

namespace API.Entities;

public class Product
{
   public int ID { get; set; }
   public required string Name { get; set; }
   public required int Price { get; set; }
   public int StockQuantity { get; set; }
}
