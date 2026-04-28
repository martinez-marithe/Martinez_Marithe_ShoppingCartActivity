using System;

class Program
{
    static Order[] historyLog = new Order[50];
    static int historyCount = 0;
    static int receiptID = 1;

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
            Console.WriteLine("2. Filter by Category");
            Console.WriteLine("3. Manage Cart");
            Console.WriteLine("4. Order History");
            Console.WriteLine("5. Exit");

            string choice;
            while (true)
            {
                Console.Write("Select No.: ");
                choice = Console.ReadLine();

                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
                    break;

                Console.WriteLine("Invalid choice. Enter 1-5 only.");
            }

            if (choice == "1")
            {
                Console.Write("Enter product name to search: ");
                string keyword = Console.ReadLine().ToLower();

                if (keyword == "")
                {
                    Console.WriteLine("Search can't be empty.");
                    Console.ReadKey();
                    continue;
                }

                bool found = false;

                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].Name.ToLower().Contains(keyword) ||
                        store[i].Category.ToLower().Contains(keyword))
                    {
                        store[i].DisplayProduct();
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No products found.");
                    Console.Write("\n[Press any key to continue...]");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("\nEnter ID: ");
                int id;

                if (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > store.Length)
                {
                    Console.WriteLine("Invalid ID.");
                    Console.ReadKey();
                    continue;
                }

                bool validMatch = store[id - 1].Name.ToLower().Contains(keyword) ||
                                  store[id - 1].Category.ToLower().Contains(keyword);

                if (!validMatch)
                {
                    Console.WriteLine("Selected product is not in search result.");
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

                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full.");
                    Console.ReadKey();
                    continue;
                }

                Product p = store[id - 1];

                if (p.HasEnoughStock(qty))
                {
                    int existing = -1;
                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].Product.Id == p.Id)
                            existing = i;
                    }

                    if (existing != -1)
                    {
                        cart[existing].Quantity = cart[existing].Quantity + qty;
                        cart[existing].Subtotal = p.GetItemTotal(cart[existing].Quantity);
                        p.DeductStock(qty);
                        Console.WriteLine("Cart updated!");
                    }
                    else
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
                }
                else
                {
                    Console.WriteLine("Not enough stock.");
                }

                string addMore;

                while (true)
                {
                    Console.Write("Add another item? (Y/N): ");
                    addMore = Console.ReadLine().ToUpper();

                    if (addMore == "Y" || addMore == "N")
                        break;

                    Console.WriteLine("Invalid input. Please enter Y or N only.");
                }
            }

            else if (choice == "2")
            {
                Console.WriteLine("\nCategories:");
                Console.WriteLine("1. Skincare");
                Console.WriteLine("2. Treatment");
                Console.WriteLine("3. Cleanser");
                
                string catChoice;

                while (true)
                {
                    Console.Write("Select No. (1-3): ");
                    catChoice = Console.ReadLine();

                    if (catChoice == "1" || catChoice == "2" || catChoice == "3")
                        break;

                    Console.WriteLine("Invalid input. Enter 1-3 only.");
                }

                string selectedCategory =
                    catChoice == "1" ? "Skincare" :
                    catChoice == "2" ? "Treatment" :
                    "Cleanser";

                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].Category == selectedCategory)
                        store[i].DisplayProduct();
                }

                Console.ReadKey();
            }

            else if (choice == "3")
            { 
                if (cartCount == 0)
                {
                    Console.WriteLine("Cart is empty.");
                    Console.Write("\n[Press any key to continue...]");
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

                string op;

                while(true)
                {

                Console.WriteLine("\n1. Checkout");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Update item quantity");
                Console.WriteLine("4. Clear Cart");
                Console.WriteLine("5. Back");

                Console.Write("Choice No.: ");
                op = Console.ReadLine();

                    if (op == "1" || op == "2" || op == "3" || op == "4" || op == "5")
                        break;
                
                    Console.WriteLine("Invalid input. Enter 1-5 only.");
                }

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
                    Console.WriteLine("Receipt No: " + receiptID.ToString("0000"));
                    Console.WriteLine("Date: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"));
                    Console.WriteLine("\nItems:");

                    for (int i = 0; i < cartCount; i++)
                    {
                        Console.WriteLine(cart[i].Product.Name + " x" +
                            cart[i].Quantity + " = P" +
                            cart[i].Subtotal);
                    }

                    Console.WriteLine("\nGrand Total: P" + total);
                    Console.WriteLine("Discount: P" + discount);
                    Console.WriteLine("Final Total: P" + finalTotal);
                    Console.WriteLine("Payment: P" + payment);
                    Console.WriteLine("Change: P" + (payment - finalTotal));

                    Console.WriteLine("\nLOW STOCK ALERT:");
                    bool lowStockFound = false;

                    for (int i = 0; i < store.Length; i++)
                    {
                        if (store[i].RemainingStock <= 5)
                        {
                            Console.WriteLine(store[i].Name + " has only " + store[i].RemainingStock + " stocks left.");
                            lowStockFound = true;
                        }
                    }

                    if (!lowStockFound)
                    {
                        Console.WriteLine("All products have enough stock.");
                    }

                    Console.Write("\n[Press any key to continue...]");
                    Console.ReadKey();

                    if (historyCount < historyLog.Length)
                    {
                        historyLog[historyCount] = new Order
                        {
                            ReceiptNo = receiptID,
                            Date = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"),
                            Total = finalTotal
                        };

                        historyCount++;
                    }
                    else
                    {
                        Console.WriteLine("Order history is full.");
                        Console.ReadKey();
                    }

                    receiptID++;
                    cartCount = 0;
                }

                else if (op == "2")
                {
                    Console.Write("Item #: ");
                    int r;

                    if (int.TryParse(Console.ReadLine(), out r) && r >= 1 && r <= cartCount)
                    {
                        cart[r - 1].Product.ReturnStock(cart[r - 1].Quantity);

                        for (int i = r - 1; i < cartCount - 1; i++)
                        {
                            cart[i] = cart[i + 1];
                        }

                        cart[cartCount - 1] = null;

                        cartCount--;

                        Console.WriteLine("Removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                    }

                    Console.ReadKey();
                }

                else if (op == "3")
                {
                    Console.Write("Item #: ");
                    int u;

                    if (int.TryParse(Console.ReadLine(), out u) && u >= 1 && u <= cartCount)
                    {
                        int oldQty = cart[u - 1].Quantity;

                        cart[u - 1].Product.ReturnStock(oldQty);

                        Console.Write("New Qty: ");
                        int newQ;

                        if (int.TryParse(Console.ReadLine(), out newQ) && newQ > 0)
                        {
                            if (cart[u - 1].Product.HasEnoughStock(newQ))
                            {
                                cart[u - 1].Quantity = newQ;
                                cart[u - 1].Subtotal = cart[u - 1].Product.GetItemTotal(newQ);
                                cart[u - 1].Product.DeductStock(newQ);

                                Console.WriteLine("Updated!");
                            }
                            else
                            {
                                Console.WriteLine("Not enough stock.");
                                cart[u - 1].Product.DeductStock(oldQty);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity.");
                            cart[u - 1].Product.DeductStock(oldQty);
                        }

                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                        Console.ReadKey();
                    }
                }

                else if (op == "4")
                {
                    for (int i = 0; i < cartCount; i++)
                    {
                        cart[i].Product.ReturnStock(cart[i].Quantity);
                        cart[i] = null;
                    }

                    cartCount = 0;

                    Console.WriteLine("Cart cleared.");
                    Console.ReadKey();
                }
            }

            else if (choice == "4")
            {
                Console.WriteLine("\nORDER HISTORY");

                if (historyCount == 0)
                {
                    Console.WriteLine("No orders yet.");
                }
                else
                {
                    for (int i = 0; i < historyCount; i++)
                    {
                        Console.WriteLine("Receipt #" + historyLog[i].ReceiptNo.ToString("0000") + " - Final Total: P" + historyLog[i].Total + " - " + historyLog[i].Date);
                    }
                }

                Console.Write("\n[Press any key to continue...]");
                Console.ReadKey();
            }

            else if (choice == "5")
            {
                string confirm;

                while (true)
                {
                    Console.Write("Exit? (Y/N): ");
                    confirm = Console.ReadLine().ToUpper();

                    if (confirm == "Y" || confirm == "N")
                        break;

                    Console.WriteLine("Invalid input.");
                }

                if (confirm == "Y")
                    running = false;
            }
        }

        Console.WriteLine("\nThank you for glowing with us, have a great day and stay hydrated!");
        Console.ReadKey();
    }
}