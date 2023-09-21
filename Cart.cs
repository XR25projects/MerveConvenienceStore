public class Cart
{
  // List of products in the cart
  public List<Product> CartItems { get; private set; }

  // Constructor to initialize the cart with an empty list of items
  public Cart()
  {
    CartItems = new List<Product>();
  }

  // Add a specified quantity of a product to the cart
  public void AddToCart(Product product, int quantity)
  {
    // Check if the product is in stock and the requested quantity is available
    if (product.Stock >= quantity)
    {
      for (int i = 0; i < quantity; i++)
      {
        CartItems.Add(product);
      }

      // Update the stock
      product.Stock -= quantity;
      Console.WriteLine($"You've added {quantity} {product.Name}(s) to your cart.");
    }
    else
    {
      Console.WriteLine($"Sorry, only {product.Stock} {product.Name}(s) are available.");
    }
  }

  // Clear all items from the cart
  public void ClearCart()
  {
    CartItems.Clear();
    Console.WriteLine("Your cart has been cleared.");
  }
}
