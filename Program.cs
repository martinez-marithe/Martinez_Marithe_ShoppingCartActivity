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

        CartItem[] cart = new CartItem[10];
        int cartCount = 0;
        string choice = "";

        do
        {
            Console.Clear();
            Console.WriteLine("=== GLOW & CARE SKINCARE STORE ===");
            for (int i = 0; i < store.Length; i++)
            {
                store[i].DisplayProduct();
            }

            Console.Write("\nEnter Product # (1-5): ");
            if (int.TryParse(Console.ReadLine(), out int pNum) && pNum >= 1 && pNum <= 5)
            {
                Product selected = store[pNum - 1];

                if (selected.RemainingStock > 0)
                {
                    Console.Write("Enter Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                    {
                        if (selected.HasEnoughStock(qty))
                        {
                            int found = -1;
                            for (int j = 0; j < cartCount; j++)
                            {
                                if (cart[j].Product.Id == selected.Id) { found = j; break; }
                            }

                            if (found != -1)
                            {
                                cart[found].Quantity += qty;
                                cart[found].Subtotal += selected.GetItemTotal(qty);
                                selected.DeductStock(qty);
                                Console.WriteLine("Updated cart quantity!");
                            }
                            else if (cartCount < 10)
                            {
                                cart[cartCount] = new CartItem { Product = selected, Quantity = qty, Subtotal = selected.GetItemTotal(qty) };
                                cartCount++;
                                selected.DeductStock(qty);
                                Console.WriteLine("Added to cart!");
                            }
                            else
                            {
                                Console.WriteLine("Cart is full (Max 10 items)!");
                            }
                        }
                        else { Console.WriteLine("Not enough stock."); }
                    }
                    else { Console.WriteLine("Invalid quantity."); }
                }
                else { Console.WriteLine("Item is out of stock!"); }
            }
            else { Console.WriteLine("Invalid product."); }

            while (true)
            {
                Console.Write("\nShop more? (Y/N): ");
                choice = Console.ReadLine()?.ToUpper() ?? "";

                if (choice == "Y" || choice == "N")
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter Y or N only.");
            }

        } while (choice == "Y");

        Console.Clear();
        Console.WriteLine("=== YOUR RECEIPT ===");
        double grandTotal = 0;
        for (int i = 0; i < cartCount; i++)
        {
            Console.WriteLine(cart[i].Product.Name + " x" + cart[i].Quantity + " = P" + cart[i].Subtotal);
            grandTotal += cart[i].Subtotal;
        }

        double discount = grandTotal >= 5000 ? grandTotal * 0.10 : 0;
        double finalTotal = grandTotal - discount;

        Console.WriteLine("\nGrand Total: P" + grandTotal);
        if (discount > 0)
        {
            Console.WriteLine("Discount (10%): -P" + discount);
        }
        Console.WriteLine("FINAL TOTAL: P" + finalTotal);

        Console.WriteLine("\n--- UPDATED STORE INVENTORY ---");
        for (int i = 0; i < store.Length; i++)
        {
            store[i].DisplayProduct();
        }

        Console.WriteLine("\nThank you for glowing with us, have a great day and stay hydrated!");
        Console.ReadKey();
    }
}