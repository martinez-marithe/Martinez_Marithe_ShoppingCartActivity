using System;

class Program
{
    static Order[] historyLog = new Order[50];
    static int historyCount = 0;
    static int receiptID = 1001;

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

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== GLOW & CARE SKINCARE STORE V2.0 ===");
            Console.WriteLine("1. Search & Add");
            Console.WriteLine("2. Manage Cart");
            Console.WriteLine("3. Order History");
            Console.WriteLine("4. Exit");
            Console.Write("Select: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Search: ");
                string keyword = Console.ReadLine().ToLower();

                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].Name.ToLower().Contains(keyword) ||
                        store[i].Category.ToLower().Contains(keyword))
                    {
                        store[i].DisplayProduct();
                    }
                }

                Console.Write("\nEnter ID: ");
                int id;

                if (!int.TryParse(Console.ReadLine(), out id) || id > store.Length)
                {
                    Console.WriteLine("Invalid ID.");
                    Console.ReadKey();
                    continue;
                }
                
                                Console.Write("Quantity: ");
                int qty;

                if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    Console.ReadKey();
                    continue;
                }

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
                else
                {
                    Console.WriteLine("Not enough stock.");
                }

                Console.ReadKey();
            }

            else if (choice == "2")
            {
                if (cartCount == 0)
                {
                    Console.WriteLine("Cart is empty.");
                    Console.ReadKey();
                    continue;
                }

                double total = 0;

                Console.WriteLine("\n--- CART ---");

                for (int i = 0; i < cartCount; i++)
                {
                    Console.WriteLine((i + 1) + ". " +
                        cart[i].Product.Name + " x" +
                        cart[i].Quantity + " = P" +
                        cart[i].Subtotal);

                    total += cart[i].Subtotal;
                }

                Console.WriteLine("\n1. Checkout");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Clear Cart");
                Console.WriteLine("5. Back");
                Console.Write("Choice: ");

                string op = Console.ReadLine();

                if (op == "1")
                {
                    double discount = total >= 5000 ? total * 0.10 : 0;
                    double finalTotal = total - discount;

                    double payment;

                    while (true)
                    {
                        Console.WriteLine("\nFinal Total: P" + finalTotal);
                        Console.Write("Payment: ");

                        if (!double.TryParse(Console.ReadLine(), out payment))
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        if (payment < finalTotal)
                        {
                            Console.WriteLine("Insufficient payment.");
                            continue;
                        }

                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("=== RECEIPT ===");
                    Console.WriteLine("Receipt No: " + receiptID);
                    Console.WriteLine("Date: " + DateTime.Now);
                    Console.WriteLine("\nItems:");

                    for (int i = 0; i < cartCount; i++)
                    {
                        Console.WriteLine(cart[i].Product.Name + " x" +
                            cart[i].Quantity + " = P" +
                            cart[i].Subtotal);
                    }

                    Console.WriteLine("\nSubtotal: P" + total);
                    Console.WriteLine("Discount: P" + discount);
                    Console.WriteLine("Final Total: P" + finalTotal);
                    Console.WriteLine("Payment: P" + payment);
                    Console.WriteLine("Change: P" + (payment - finalTotal));

                    Console.WriteLine("\nLOW STOCK ALERT:");
                    for (int i = 0; i < store.Length; i++)
                    {
                        if (store[i].RemainingStock <= 5)
                        {
                            Console.WriteLine(store[i].Name + store[i].RemainingStock + " left");
                        }
                    }

                    historyLog[historyCount] = new Order
                    {
                        ReceiptNo = receiptID,
                        Date = DateTime.Now.ToString(),
                        Total = finalTotal
                    };

                    historyCount++;
                    receiptID++;
                    cartCount = 0;

                    Console.ReadKey();
                }
            }
        }
    }
} 
    