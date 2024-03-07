public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // TODO: Initialize the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // TODO: Update the item's price with the new price.
        Price = newPrice; // Update the item's price with the new price.
        Console.WriteLine($"Price of {ItemName} updated to {Price}");
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // TODO: Increase the item's stock quantity by the additional quantity.
        QuantityInStock += additionalQuantity; // Increase the item's stock quantity by the additional quantity.
        Console.WriteLine($"{additionalQuantity} {ItemName}(s) added to stock. Tot{QuantityInStock}");

    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // TODO: Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
            Console.WriteLine($"{quantitySold} {ItemName}(s) sold of item1 or item2.");
        }
        else
        {
            Console.WriteLine($"Not enough {ItemName} in stock to sell.");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // TODO: Return true if the item is in stock (quantity > 0), otherwise false.
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        // TODO: Print the details of the item (name, id, price, and stock quantity).
        Console.WriteLine($"Name: {ItemName}");
        Console.WriteLine($"ID: {ItemId}");
        Console.WriteLine($"Price: ${Price:F2}");
        Console.WriteLine($"Quantity: {QuantityInStock}");
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 1. Print details of all items.
        // 2. Sell some items and then print the updated details.
        // 3. Restock an item and print the updated details.
        // 4. Check if an item is in stock and print a message accordingly.

        // Implement logic to interact with these objects.
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Print details of all items.");
            Console.WriteLine("2. Sell some items and then print the updated details.");
            Console.WriteLine("3. Restock an item and print the updated details.");
            Console.WriteLine("4. Check if an item is in stock and print a message accordingly.");

            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nDetails of all items:");
                        item1.PrintDetails();
                        item2.PrintDetails();
                        break;

                    case 2:
                        Console.Write("\nEnter the quantity of items to sell: ");
                        if (int.TryParse(Console.ReadLine(), out int quantityToSell))
                        {
                            item1.SellItem(quantityToSell);
                            item2.SellItem(quantityToSell);
                            Console.WriteLine("\nDetails after selling items:");
                            item1.UpdatePrice(item1.Price);   // i give some discount
                            item2.UpdatePrice(item2.Price);
                            item1.PrintDetails();
                            item2.PrintDetails();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid quantity.");
                        }
                        break;

                    case 3:
                        Console.Write("\nEnter the quantity to restock: ");
                        if (int.TryParse(Console.ReadLine(), out int quantityToRestock))
                        {
                            item1.RestockItem(quantityToRestock);
                            Console.WriteLine("\nDetails after restocking item 1:laptops");
                            item1.PrintDetails();
                            item2.RestockItem(quantityToRestock);
                            Console.WriteLine("\nDetails after restocking item 2:smartphone");
                            item2.PrintDetails();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid quantity.");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"\nAvailable {item1.ItemName} in stock? {item1.IsInStock()}");
                        Console.WriteLine($"Available {item2.ItemName} in stock? {item2.IsInStock()}");
                        break;

                    case 5:
                        Console.WriteLine("end of program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}