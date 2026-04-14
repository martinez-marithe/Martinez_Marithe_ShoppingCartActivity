using System;

public class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine(Id + ". " + Name + " - P" + Price + " (Stock: " + RemainingStock + ")");
    }

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }
}
