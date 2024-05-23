using System;

public interface IPurchasable
{
    void Purchase(decimal budget);
}
public abstract class LuxuryItem : IPurchasable
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    protected string Material { get; set; }
    protected bool IsLimitedEdition { get; set; }
    protected string Color { get; set; }

    public LuxuryItem()
    {
        Brand = "Unknown";
        Model = "Unknown";
        Price = 0;
        Material = "Unknown";
        IsLimitedEdition = false;
        Color = "Unknown";
    }

    public LuxuryItem(string brand, string model, decimal price)
    {
        Brand = brand;
        Model = model;
        Price = price;
        Material = "Leather";
        IsLimitedEdition = false;
        Color = "Black";
    }

    public LuxuryItem(string brand, string model, decimal price, string material, bool isLimitedEdition, string color)
    {
        Brand = brand;
        Model = model;
        Price = price;
        Material = material;
        IsLimitedEdition = isLimitedEdition;
        Color = color;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Material: {Material}");
        Console.WriteLine($"Limited Edition: {(IsLimitedEdition ? "Yes" : "No")}");
        Console.WriteLine($"Color: {Color}");
    }

    public bool IsWithinBudget(decimal budget)
    {
        return Price <= budget;
    }

    protected bool Authenticate()
    {
        return true;
    }

    public virtual void Purchase(decimal budget)
    {
        if (IsWithinBudget(budget))
        {
            if (Authenticate())
            {
                Console.WriteLine($"Congratulations! You have purchased the {Brand} {Model}.");
            }
            else
            {
                Console.WriteLine("Authentication failed. Purchase unsuccessful.");
            }
        }
        else
        {
            Console.WriteLine($"The price of {Brand} {Model} is beyond your budget. Sorry but your Purchase is unsuccessful.");
        }
    }
}

public class LuxuryBag : LuxuryItem
{
    public LuxuryBag() : base() { }

    public LuxuryBag(string brand, string model, decimal price) : base(brand, model, price)
    {
        Color = "Pink";
    }

    public LuxuryBag(string brand, string model, decimal price, string material, bool isLimitedEdition, string color)
        : base(brand, model, price, material, isLimitedEdition, color) { }
}

public class LuxuryShoe : LuxuryItem
{
    public LuxuryShoe() : base() { }

    public LuxuryShoe(string brand, string model, decimal price) : base(brand, model, price)
    {
        Color = "White";
    }

    public LuxuryShoe(string brand, string model, decimal price, string material, bool isLimitedEdition, string color)
        : base(brand, model, price, material, isLimitedEdition, color) { }
}

public class LuxuryWatch : LuxuryItem
{
    public LuxuryWatch() : base() { }

    public LuxuryWatch(string brand, string model, decimal price) : base(brand, model, price)
    {
        Color = "Gold";
    }

    public LuxuryWatch(string brand, string model, decimal price, string material, bool isLimitedEdition, string color)
        : base(brand, model, price, material, isLimitedEdition, color) { }
}

public class LuxuryAccessory : LuxuryItem
{
    public LuxuryAccessory() : base() { }

    public LuxuryAccessory(string brand, string model, decimal price) : base(brand, model, price)
    {
        Color = "Silver";
    }

    public LuxuryAccessory(string brand, string model, decimal price, string material, bool isLimitedEdition, string color)
        : base(brand, model, price, material, isLimitedEdition, color) { }
}

class Program
{
    static void Main(string[] args)
    {
        LuxuryItem bag = new LuxuryBag("Marc Jacobs", "Snapshot", 13000);
        LuxuryItem shoe = new LuxuryShoe("Nike", "Air Max", 15000, "Leather", false, "White");
        LuxuryItem watch = new LuxuryWatch("Rolex", "Daytona", 1200000, "Gold", true, "Gold");
        LuxuryItem accessory = new LuxuryAccessory("Tiffany & Co.", "Necklace", 580000, "Gold", true, "Silver");

        bag.DisplayDetails();
        shoe.DisplayDetails();
        watch.DisplayDetails();
        accessory.DisplayDetails();

        decimal budget = 500000;
        Console.WriteLine($"Is the bag within budget? {bag.IsWithinBudget(budget)}");
        Console.WriteLine($"Is the shoe within budget? {shoe.IsWithinBudget(budget)}");
        Console.WriteLine($"Is the watch within budget? {watch.IsWithinBudget(budget)}");
        Console.WriteLine($"Is the accessory within budget? {accessory.IsWithinBudget(budget)}");

        bag.Purchase(budget);
        shoe.Purchase(budget);
        watch.Purchase(budget);
        accessory.Purchase(budget);
    }
}
