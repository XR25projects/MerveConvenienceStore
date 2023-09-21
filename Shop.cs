public class Shop
{
  // List to store available products
  private List<Product> products;

  // Dictionary to store initial stock values of products
  private Dictionary<string, int> initialStockValues;

  // Cart object for handling shopping cart functionality
  private Cart cart;

  // Cash amount available for shopping
  public int cash;

  // Constructor to initialize the shop with initial cash and products
  public Shop(int initialCash)
  {
    // Initialize list of products with default values
    products = new List<Product>
      {
        new Product {
          Name = "Camel",
          Description = "If you don't have a car, this is the best option I have",
          Price = 165,
          Stock = 10
        },
        new Product {
          Name = "Kangal Dog",
          Description = "The strongest dog in the world",
          Price = 180,
          Stock = 20
        },
        new Product {
          Name = "Lahmacun",
          Description = "Turkish delicacies my favorite",
          Price = 20,
          Stock = 35
        },
        new Product {
          Name = "Cat",
          Description = "Crazy",
          Price = 80,
          Stock = 7
        }
      };

    // Initialize dictionary to store initial stock values
    initialStockValues = new Dictionary<string, int>();

    // Update initial stock values
    UpdateInitialStock();

    // Initialize shopping cart
    cart = new Cart();

    // Set initial cash amount
    cash = initialCash;
  }

  // Display available products to the user
  public void ListProducts()
  {
    Console.WriteLine("");
    Console.WriteLine("Select a product for detailed description: ");
    int i = 1;
    // List available products
    foreach (var product in products)
    {
      Console.WriteLine($"{i++}. {product.Name} - In Stock: {product.Stock} - Price: {product.Price} SEK");
    }

    int choice = int.Parse(Console.ReadLine()); // Get user input
    ListProductDetails(choice);
  }

  // Display details of a selected product and handle user input
  public void ListProductDetails(int choice)
  {
    int i = 1;

    foreach (var product in products)
    {
      if (choice == i)
      {
        Console.WriteLine($"{product.Name} - {product.Description}");

        Console.WriteLine("Add to cart? (Yes / No): ");
        string input = Console.ReadLine(); // Get user input

        if (input.ToLower() == "Yes".ToLower())
        {
          Console.WriteLine($"How many? ({product.Stock} in stock): ");
          int amount = int.Parse(Console.ReadLine()); // Get user input

          cart.AddToCart(product, amount);
        }
        else if (input.ToLower() == "No".ToLower())
        {
          Console.WriteLine("You've not added anything to your cart.");
        }
        else
        {
          Console.WriteLine("Invalid input.");
        }
        break;
      }
      i++;
    }
  }

  // Display the contents of the shopping cart and handle user input
  public void ListCart()
  {
    if (cart.CartItems.Count == 0)
    {
      Console.WriteLine("Your cart is empty.\n");
      return;
    }

    Console.WriteLine("Your Cart: ");
    foreach (var item in cart.CartItems)
    {
      Console.WriteLine($"{item.Name} - Price: {item.Price} SEK");
    }
    int totalCost = cart.CartItems.Sum(item => item.Price);
    Console.WriteLine($"Total cost: {totalCost} SEK");

    Console.WriteLine("Do you want to purchase everything in this cart?");
    Console.WriteLine("If you chose 'No', you will be returned to the main menu and your cart will be reset.");
    Console.WriteLine("(Yes / No): ");

    string input = Console.ReadLine(); // Get user input

    if (input.ToLower() == "Yes".ToLower())
    {
      PurchaseCart();
    }
    else if (input.ToLower() == "No".ToLower())
    {
      Console.WriteLine("You've not purchased anything.");
      cart.ClearCart();
      ResetStock();
    }
    else
    {
      Console.WriteLine("Invalid input.");
    }
  }

  // Process the purchase of items in the cart
  public void PurchaseCart()
  {
    int totalCost = cart.CartItems.Sum(item => item.Price);
    if (cash >= totalCost)
    {
      cash -= totalCost;
      cart.CartItems.Clear();
      UpdateInitialStock();
      Console.WriteLine($"You've purchased the items. You now have {cash} SEK left.");
    }
    else
    {
      Console.WriteLine("You don't have enough money to purchase the items in your cart.");
      cart.ClearCart();
      ResetStock();
    }
  }

  // Reset the stock of products to their initial values
  public void ResetStock()
  {
    foreach (var product in products)
    {
      product.Stock = initialStockValues[product.Name];
    }
  }

  // Update the initial stock values based on the current stock
  public void UpdateInitialStock()
  {
    foreach (var product in products)
    {
      initialStockValues[product.Name] = product.Stock;
    }
  }

}
