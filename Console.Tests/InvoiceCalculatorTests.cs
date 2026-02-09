using OrderCalculator.Interfaces;

namespace Console.Tests;

/// <summary>
/// Tests for invoice calculation logic.
/// Implement the IInvoiceCalculator interface to make these tests pass.
/// </summary>
public class InvoiceCalculatorTests
{
    // TODO: Replace 'null!' with your implementation, e.g.:
    // private readonly IInvoiceCalculator _calculator = new InvoiceCalculator(...);
    private readonly IInvoiceCalculator _calculator = null!;

    [Fact]
    public void Calculate_SingleItem_RegularCustomer()
    {
        var items = new[] { new OrderItem("Laptop", 1, 1000m) };

        var result = _calculator.Calculate(items, "regular");

        Assert.Equal(1000m, result.Subtotal);
        Assert.Equal(0m, result.DiscountPercent);
        Assert.Equal(0m, result.DiscountAmount);
        Assert.Equal(80m, result.TaxAmount);      // 8% of 1000
        Assert.Equal(1080m, result.Total);        // 1000 + 80
    }

    [Fact]
    public void Calculate_SingleItem_PremiumCustomer()
    {
        var items = new[] { new OrderItem("Laptop", 1, 1000m) };

        var result = _calculator.Calculate(items, "premium");

        Assert.Equal(1000m, result.Subtotal);
        Assert.Equal(0.10m, result.DiscountPercent);
        Assert.Equal(100m, result.DiscountAmount);  // 10% of 1000
        Assert.Equal(72m, result.TaxAmount);        // 8% of 900
        Assert.Equal(972m, result.Total);           // 1000 - 100 + 72
    }

    [Fact]
    public void Calculate_SingleItem_VipCustomer()
    {
        var items = new[] { new OrderItem("Laptop", 1, 1000m) };

        var result = _calculator.Calculate(items, "vip");

        Assert.Equal(1000m, result.Subtotal);
        Assert.Equal(0.20m, result.DiscountPercent);
        Assert.Equal(200m, result.DiscountAmount);  // 20% of 1000
        Assert.Equal(64m, result.TaxAmount);        // 8% of 800
        Assert.Equal(864m, result.Total);           // 1000 - 200 + 64
    }

    [Fact]
    public void Calculate_MultipleItems()
    {
        var items = new[]
        {
            new OrderItem("Laptop", 2, 999.99m),
            new OrderItem("Mouse", 3, 29.99m)
        };

        var result = _calculator.Calculate(items, "premium");

        Assert.Equal(2089.95m, result.Subtotal);    // (2 * 999.99) + (3 * 29.99)
        Assert.Equal(0.10m, result.DiscountPercent);
        Assert.Equal(208.995m, result.DiscountAmount);
        // Tax: 8% of (2089.95 - 208.995) = 8% of 1880.955 = 150.4764
        Assert.Equal(150.4764m, result.TaxAmount);
        // Total: 2089.95 - 208.995 + 150.4764 = 2031.4314
        Assert.Equal(2031.4314m, result.Total);
    }

    [Fact]
    public void Calculate_EmptyOrder()
    {
        var items = Array.Empty<OrderItem>();

        var result = _calculator.Calculate(items, "regular");

        Assert.Equal(0m, result.Subtotal);
        Assert.Equal(0m, result.DiscountAmount);
        Assert.Equal(0m, result.TaxAmount);
        Assert.Equal(0m, result.Total);
    }

    [Fact]
    public void Calculate_QuantityMultipliesPrice()
    {
        var items = new[] { new OrderItem("Item", 5, 10m) };

        var result = _calculator.Calculate(items, "regular");

        Assert.Equal(50m, result.Subtotal);
    }
}
