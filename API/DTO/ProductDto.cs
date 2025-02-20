using System;

namespace API.DTO;

public class ProductDto
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public int StockQuantity { get; set; }
}
