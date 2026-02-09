namespace OrderCalculator.Interfaces;

public interface IDiscountCalculator
{
    decimal GetDiscountPercent(string customerType);
}
