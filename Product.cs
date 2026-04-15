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

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }
}

class Program
{
    static void main()
    {
        Product p1 = new Product();
        p1.Id = 1;
        p1.Name = "Mineral Sunscreen";
        p1.Price = 1200;
        p1.RemainingStock = 5;

        p1.DisplayProduct();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}