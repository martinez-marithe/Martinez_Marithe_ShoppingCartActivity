using System;

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
