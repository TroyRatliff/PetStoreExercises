using static Program;
using System.Text.Json;

Console.WriteLine("Press 1 to add a product");
Console.WriteLine("Type 'exit' to quit");
string userInput = "";
while (userInput != "exit")
{
    userInput = Console.ReadLine().ToLower();
    if (userInput == "1")
    {
        DogLeash DogLeash = new DogLeash();

        Console.WriteLine("Enter the product name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the price of item: ");
        string itemPrice = Console.ReadLine();
        double price = double.Parse(itemPrice);

        Console.WriteLine("Enter the quantity of item: ");
        string itemQuantity = Console.ReadLine();
        double quantity = double.Parse(itemQuantity);

        Console.WriteLine("Enter a description of item: ");
        string description = Console.ReadLine();

        Console.WriteLine("Product details: ");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Price: " + price);
        Console.WriteLine("Quantity: " + quantity);
        Console.WriteLine("Description: " + description);

    }
}

public class Product
{
    string Name;
    decimal Price;
    int Quatity;
    string Description;
}
public class CatFood : Product
{
    double WeightPounds;
    bool KittenFood;
}
public class DogLeash : Product
{
    int LengthInches;
    string Material;
}
