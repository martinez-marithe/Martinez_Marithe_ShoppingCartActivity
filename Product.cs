using System;

public class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine(Id + ". " + Name + " - P" + Price + " (Stock: " + RemainingStock + ")");
    }
}

class Program
{
    static void main()
    {
        Product p1 = new Product { Id = 1, Name = "Mineral sunscreen", Price = 1200, RemainingStock = 10 };
        p1.DisplayProduct();
        Console.ReadKey();
    }
}