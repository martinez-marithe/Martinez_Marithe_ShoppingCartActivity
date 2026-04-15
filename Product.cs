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
        Product[] store = new Product[5];
        store[0] = new Product { Id = 1, Name = "Mineral Sunscreen", Price = 1200, RemainingStock = 10 };
        store[1] = new Product { Id = 2, Name = "AHA/BHA Exfoliant Set", Price = 5500, RemainingStock = 3 };
        store[2] = new Product { Id = 3, Name = "Vitamin C Serum", Price = 1900, RemainingStock = 7 };
        store[3] = new Product { Id = 4, Name = "Cleansing Oil", Price = 800, RemainingStock = 12 };
        store[4] = new Product { Id = 5, Name = "Gentle Facial Cleanser", Price = 560, RemainingStock = 15 };

        Console.WriteLine("=== GLOW & CARE SKINCARE STORE ===");
        for (int i = 0; i < store.Length; i++)
        {
            store[i].DisplayProduct();
        }
        Console.ReadKey();
    }
}