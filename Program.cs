public partial class Program
{
  static void Main()
  {
    bool isStart = true; // Used to display the intro message only once

    int initialCash = 500; // Initial cash

    // Create a new instance of the Shop class with the initial cash
    Shop shop = new Shop(initialCash);

    // Intro & display menu
    void DisplayMenu()
    {
      Console.WriteLine("\n");
      Console.WriteLine($"Your balance is {shop.cash} SEK.");
      Console.WriteLine("1. List available products");
      Console.WriteLine("2. List products in cart");
      Console.WriteLine("3. Quit");
      Console.WriteLine("");
    }

    while (shop.cash >= 0) // As long as we have money to spend we can continue shopping
    {
      if (isStart == true)
      {
        Console.WriteLine("\nWelcome to the Turkish shop! 🤗");
        Console.WriteLine("--------------------------------");
        isStart = false;
      }

      DisplayMenu();

      int choice = int.Parse(Console.ReadLine()); // Get user input

      switch (choice) // Handle user input
      {
        case 1: // List available products
          shop.ListProducts();
          break;
        case 2: // List products in cart
          shop.ListCart();
          break;
        case 3: // Quit
          Console.WriteLine("\nThank you come again! 🤗\n");
          return;
        default:
          Console.WriteLine("\nInvalid choice. Please try again.\n");
          break;
      }
    }
  }
}
