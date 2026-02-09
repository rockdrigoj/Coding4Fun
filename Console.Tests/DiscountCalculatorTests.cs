using OrderCalculator.Interfaces;

namespace Console.Tests;

/// <summary>
/// Tests for discount calculation logic.
/// Implement the IDiscountCalculator interface to make these tests pass.
/// </summary>
public class DiscountCalculatorTests
{
    // TODO: Replace 'null!' with your implementation, e.g.:
    // private readonly IDiscountCalculator _calculator = new DiscountCalculator();
    private readonly IDiscountCalculator _calculator = null!;

    [Fact]
    public void RegularCustomer_ShouldHaveNoDiscount()
    {
        var discount = _calculator.GetDiscountPercent("regular");
        Assert.Equal(0m, discount);
    }

    [Fact]
    public void PremiumCustomer_ShouldHave10PercentDiscount()
    {
        var discount = _calculator.GetDiscountPercent("premium");
        Assert.Equal(0.10m, discount);
    }

    [Fact]
    public void VipCustomer_ShouldHave20PercentDiscount()
    {
        var discount = _calculator.GetDiscountPercent("vip");
        Assert.Equal(0.20m, discount);
    }

    [Theory]
    [InlineData("REGULAR")]
    [InlineData("Regular")]
    [InlineData("PREMIUM")]
    [InlineData("Premium")]
    [InlineData("VIP")]
    [InlineData("Vip")]
    public void CustomerType_ShouldBeCaseInsensitive(string customerType)
    {
        // Should not throw and should return a valid discount
        var discount = _calculator.GetDiscountPercent(customerType);
        Assert.True(discount >= 0m && discount <= 1m);
    }

    [Fact]
    public void UnknownCustomerType_ShouldDefaultToNoDiscount()
    {
        var discount = _calculator.GetDiscountPercent("unknown");
        Assert.Equal(0m, discount);
    }
}
