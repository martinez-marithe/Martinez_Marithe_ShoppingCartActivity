using System;

public class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;
    public string Category; 

    public void DisplayProduct() 
    { 
        Console.WriteLine(Id + ". [" + Category + "] " + Name + " - P" + Price + " (Stock: " + RemainingStock + ")"); 
    }

    public double GetItemTotal(int qty) { return Price * qty; }
    public bool HasEnoughStock(int qty) { return RemainingStock >= qty; }
    public void DeductStock(int qty) { RemainingStock -= qty; }
    public void ReturnStock(int qty) { RemainingStock += qty; }
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
