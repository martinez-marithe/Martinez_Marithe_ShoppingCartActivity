using System;

public class SkincareProduct : Product
{
    private int spfLevel;

    public SkincareProduct(int id , string name, double price, int remainingStock, string category, int spfLevel)
        : base(id, name, price, remainingStock, category)
    {
        this.spfLevel = spfLevel;
    }

    public int GetSpfLevel()
    {
        return spfLevel;
    }

    public void SetSpfLevel(int spfLevel)
    {
        this.spfLevel = spfLevel;
    }

    public void DisplaySkincareProduct()
    {
        Console.WriteLine(GetId() + ". [" + GetCategory() + "] " + GetName() + " - P" + GetPrice() + " (Stock: " + GetRemainingStock() + ") SPF: " + spfLevel);
    }
}