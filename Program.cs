using System;

class Program
{
    static void Main()
    {
        Product[] store = new Product[5];
        store[0] = new Product { Id = 1, Name = "Mineral Sunscreen", Price = 1200, RemainingStock = 10, Category = "Skincare" };
        store[1] = new Product { Id = 2, Name = "AHA/BHA Exfoliant Set", Price = 5500, RemainingStock = 3, Category = "Treatment" };
        store[2] = new Product { Id = 3, Name = "Vitamin C Serum", Price = 1900, RemainingStock = 7, Category = "Treatment" };
        store[3] = new Product { Id = 4, Name = "Cleansing Oil", Price = 800, RemainingStock = 12, Category = "Cleanser" };
        store[4] = new Product { Id = 5, Name = "Gentle Facial Cleanser", Price = 560, RemainingStock = 15, Category = "Cleanser" };

        CartItem[] cart = new CartItem[20];
        int cartCount = 0;

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        Product p = store[id - 1];

        if (p.HasEnoughStock(qty))
        {
            cart[cartCount] = new CartItem
            {
                Product = p,
                Quantity = qty,
                Subtotal = p.GetItemTotal(qty)
            };

            cartCount++;
            p.DeductStock(qty);

            Console.WriteLine("Added to cart!");
        }

        Console.ReadKey();
    }
}