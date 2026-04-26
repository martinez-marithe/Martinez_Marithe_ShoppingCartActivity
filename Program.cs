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
        bool isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Search & Add | 2. View Cart | 3. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter search: ");
                string find = Console.ReadLine().ToLower();
                for (int i = 0; i < store.Length; i++)
                    if (store[i].Name.ToLower().Contains(find) || store[i].Category.ToLower().Contains(find)) store[i].DisplayProduct();

                Console.Write("\nID to add: ");
                int id = int.Parse(Console.ReadLine());
                Product p = store[id - 1];
                if (p.RemainingStock > 0)
                {
                    cart[cartCount++] = new CartItem { Product = p, Quantity = 1, Subtotal = p.Price };
                    p.DeductStock(1);
                    Console.WriteLine("Added!");
                }
                Console.ReadKey();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("--- MANAGE CART ---");
                for (int i = 0; i < cartCount; i++)
                    Console.WriteLine((i + 1) + ". " + cart[i].Product.Name + " - P" + cart[i].Subtotal);

                Console.WriteLine("\n[R] Remove | [C] Clear | [B] Back");
                string op = Console.ReadLine().ToUpper();

                if (op == "R") ;
                {
                    Console.Write("Remove Item #: ");
                    int r = int.Parse(Console.ReadLine()) - 1;
                    if (r >= 0 && r < cartCount)
                    {
                        cart[r].Product.ReturnStock(cart[r].Quantity);
                        for (int i = r; i < cartCount - 1; i++) cart[i] = cart[i + 1];
                        cartCount--;
                    }
                    else if (op == "C")
                        for (int i = 0; i < cartCount; i++) cart[i].Product.ReturnStock(cart[i].Quantity);
                    cartCount = 0;
                }
            }
            else if (choice == "3") isAppRunning = false;
        }
    }
}