using System;

public class Product
{
    private int id;
    private string name;
    private double price;
    private int remainingStock;
    private string category; 

    public Product(int id, string name, double price, int remainingStock, string category)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.remainingStock = remainingStock;
        this.category = category;
    }

    public Product()
    {
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public double GetPrice() { return price; }
    public int GetRemainingStock() { return remainingStock; }
    public string GetCategory() { return category; }

    public void SetId(int id) { this.id = id; }
    public void SetName(string name) { this.name = name; }
    public void SetPrice(double price) { this.price = price; }
    public void SetCategory(string category) { this.category = category; }

    public void DisplayProduct()
    {
        Console.WriteLine(id + ". [" + category + "] " + name + " - P" + price + " (Stock: " + remainingStock + ")");
    }

    public double GetItemTotal(int qty) { return price * qty; }
    public bool HasEnoughStock(int qty) { return remainingStock >= qty; }
    public void DeductStock(int qty) { remainingStock -= qty; }
    public void ReturnStock(int qty) { remainingStock += qty; }
}

public class CartItem
{
    public Product Product;
    public int Quantity;
    public double Subtotal;
}

public class Order
{
    public int ReceiptNo;
    public string Date;
    public double Total;
}
