
using System.Text.Json;
var productLogic = new ProductLogic();

Console.WriteLine("Press 1 to add a product");
Console.WriteLine("Press 2 to view a Dog Leash product ");
Console.WriteLine("Type 'exit' to quit");
string userInput = "";
while (userInput != "exit")
{
    userInput = Console.ReadLine().ToLower();
    if (userInput == "1")
    {
        DogLeash dogLeash = new DogLeash();

        Console.WriteLine("Enter the product name: ");
        dogLeash.Name = Console.ReadLine();

        Console.WriteLine("Enter the price of item: ");
        dogLeash.Price = (decimal)double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the quantity of item: ");
        dogLeash.Quantity = (int)double.Parse(Console.ReadLine());

        Console.WriteLine("Enter a description of item: ");
        dogLeash.Description = Console.ReadLine();

        Console.WriteLine("Product details: ");
        Console.WriteLine("Name: " + dogLeash.Name);
        Console.WriteLine("Price: " + dogLeash.Price);
        Console.WriteLine("Quantity: " + dogLeash.Quantity);
        Console.WriteLine("Description: " + dogLeash.Description);

        productLogic.AddProduct(dogLeash);
        Console.WriteLine("Thank you! Your product was added.");
    }
    else if (userInput == "2")
    {
        Console.WriteLine("What is the name of the dog leash you would like to view? ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetDogLeashByName(dogLeashName);
        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        Console.WriteLine();
    }

    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a Dog Leash Product");
    Console.WriteLine("Type 'exit' to quit");
    

}
public class ProductLogic
{
    private List<Product> _products;
    private Dictionary<string, DogLeash> dogLeashDictionary;
    private Dictionary<string, CatFood> catFoodDictionary;

    public ProductLogic()
    {
        _products = new List<Product>();
        dogLeashDictionary = new Dictionary<string, DogLeash>();
        catFoodDictionary = new Dictionary<string, CatFood>();
    }
    public DogLeash GetDogLeashByName(string name)
    {
        try
        {
            return dogLeashDictionary[name];
        }
        catch(Exception ex)
        {
            Console.WriteLine("Product counldn't be found.");
            return null;
        }
        
    }
    public void AddProduct(Product product)
    { 
        if (product is DogLeash)
        {
            DogLeash dogLeashProduct = (DogLeash)product;
            dogLeashDictionary.Add(dogLeashProduct.Name, dogLeashProduct);
        }
        else if (product is CatFood)
        {
            CatFood catFoodProduct = (CatFood)product;
            catFoodDictionary.Add(catFoodProduct.Name, catFoodProduct);
        }
        _products.Add(product);

    }
    public List<Product> GetAllProducts()
    {
        return _products;
    }

}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}
public class CatFood : Product
{
    public double WeightPounds { get; set; }
    public bool KittenFood { get; set; }
}
public class DogLeash : Product
{
    public int LengthInches { get; set; }
    public string Material { get; set; }
}
public class DryCatFood : CatFood
{
    public double WeightPounds { get; set; }
}