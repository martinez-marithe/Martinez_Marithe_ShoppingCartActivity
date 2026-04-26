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

        bool isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            Console.WriteLine("=== GLOW & CARE SKINCARE STORE - SEARCH MORE ===");
            Console.WriteLine("1. Search & Browse");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter keyword (Name/Category): ");
                string find = Console.ReadLine().ToLower();
                Console.WriteLine("\n--- Results ===");
                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].Name.ToLower().Contains(find) || store[i].Category.ToLower().Contains(find))
                        store[i].DisplayProduct();
                }
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
            else if (choice == "2") isAppRunning = false;
        }
    }
}



            
