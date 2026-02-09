using OrderCalculator.Interfaces;

namespace Console.Tests;

/// <summary>
/// Tests for tax calculation logic.
/// Implement the ITaxCalculator interface to make these tests pass.
/// </summary>
public class TaxCalculatorTests
{
    // TODO: Replace 'null!' with your implementation, e.g.:
    // private readonly ITaxCalculator _calculator = new TaxCalculator();
    private readonly ITaxCalculator _calculator = null!;

    [Fact]
    public void Tax_ShouldBe8Percent()
    {
        var tax = _calculator.CalculateTax(100m);
        Assert.Equal(8m, tax);
    }

    [Fact]
    public void Tax_ShouldHandleDecimalAmounts()
    {
        var tax = _calculator.CalculateTax(99.99m);
        Assert.Equal(7.9992m, tax);
    }

    [Fact]
    public void Tax_ShouldBeZeroForZeroAmount()
    {
        var tax = _calculator.CalculateTax(0m);
        Assert.Equal(0m, tax);
    }

    [Fact]
    public void Tax_ShouldHandleLargeAmounts()
    {
        var tax = _calculator.CalculateTax(10000m);
        Assert.Equal(800m, tax);
    }
}
