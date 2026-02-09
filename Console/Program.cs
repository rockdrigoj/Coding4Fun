// Order Calculator - SOLID Refactoring Exercise
// Your task: Refactor this code applying SOLID principles

var items = new List<(string Name, int Quantity, decimal Price)>();

Console.Write("Customer type (regular/premium/vip): ");
var customerType = Console.ReadLine()?.ToLower() ?? "regular";

while (true)
{
    Console.Write("Product name (or 'done'): ");
    var name = Console.ReadLine();

    if (string.IsNullOrEmpty(name) || name.ToLower() == "done")
        break;

    Console.Write("Quantity: ");
    if (!int.TryParse(Console.ReadLine(), out var quantity) || quantity <= 0)
    {
        Console.WriteLine("Invalid quantity. Try again.");
        continue;
    }

    Console.Write("Unit price: ");
    if (!decimal.TryParse(Console.ReadLine(), out var price) || price < 0)
    {
        Console.WriteLine("Invalid price. Try again.");
        continue;
    }

    items.Add((name, quantity, price));
}

// Calculate subtotal
decimal subtotal = 0;
foreach (var item in items)
{
    subtotal += item.Quantity * item.Price;
}

// Calculate discount based on customer type
decimal discountPercent = 0;
if (customerType == "premium")
{
    discountPercent = 0.10m;
}
else if (customerType == "vip")
{
    discountPercent = 0.20m;
}
decimal discountAmount = subtotal * discountPercent;

// Calculate tax (8%)
decimal taxRate = 0.08m;
decimal taxAmount = (subtotal - discountAmount) * taxRate;

// Calculate total
decimal total = subtotal - discountAmount + taxAmount;

// Print invoice
Console.WriteLine();
Console.WriteLine("========== INVOICE ==========");
Console.WriteLine($"Customer Type: {char.ToUpper(customerType[0]) + customerType.Substring(1)}");
Console.WriteLine();
Console.WriteLine("Items:");
foreach (var item in items)
{
    var lineTotal = item.Quantity * item.Price;
    Console.WriteLine($"- {item.Name} (x{item.Quantity}) @ ${item.Price:F2} = ${lineTotal:F2}");
}
Console.WriteLine();
Console.WriteLine($"Subtotal: ${subtotal:F2}");
if (discountPercent > 0)
{
    Console.WriteLine($"Discount ({discountPercent * 100:F0}%): -${discountAmount:F2}");
}
Console.WriteLine($"Tax (8%): ${taxAmount:F2}");
Console.WriteLine("-----------------------------");
Console.WriteLine($"TOTAL: ${total:F2}");
Console.WriteLine("=============================");
