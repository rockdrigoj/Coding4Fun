namespace OrderCalculator.Interfaces;

public record OrderItem(string Name, int Quantity, decimal UnitPrice);

public record InvoiceResult(
    decimal Subtotal,
    decimal DiscountPercent,
    decimal DiscountAmount,
    decimal TaxAmount,
    decimal Total
);

public interface IInvoiceCalculator
{
    InvoiceResult Calculate(IEnumerable<OrderItem> items, string customerType);
}
