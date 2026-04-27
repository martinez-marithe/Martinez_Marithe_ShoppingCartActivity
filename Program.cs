using System;

class Program
{
    static void Main()
    {
        Product[] store = new Product[5];
        CartItem[] cart = new CartItem[20];
        int cartCount = 0;

        store[0] = new Product { Id = 1, Name = "Mineral Sunscreen", Price = 1200, RemainingStock = 10, Category = "Skincare" };
        store[1] = new Product { Id = 2, Name = "AHA/BHA Exfoliant Set", Price = 5500, RemainingStock = 3, Category = "Treatment" };
        store[2] = new Product { Id = 3, Name = "Vitamin C Serum", Price = 1900, RemainingStock = 7, Category = "Treatment" };
        store[3] = new Product { Id = 4, Name = "Cleansing Oil", Price = 800, RemainingStock = 12, Category = "Cleanser" };
        store[4] = new Product { Id = 5, Name = "Gentle Facial Cleanser", Price = 560, RemainingStock = 15, Category = "Cleanser" };

        Console.WriteLine("1. Add | 2. View Cart");
        string choice = Console.ReadLine();

        if (choice == "2")
        {
            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine(cart[i].Product.Name + " x" + cart[i].Quantity);
            }

            Console.WriteLine("1. Remove 2. Clear");

            string op = Console.ReadLine();

            if (op == "2")
            {
                cartCount = 0;
                Console.WriteLine("Cart cleared.");
            }
        }

        Console.ReadKey();
    }
}