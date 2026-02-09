# SOLID Refactoring Exercise

## Overview
This console application calculates invoices for customer orders. The current implementation works correctly but violates several SOLID principles.

**Your task:** Refactor the code to apply SOLID principles while maintaining the same functionality.

## How to Run
```bash
dotnet run
```

## Current Functionality
1. Ask for customer type (regular, premium, or vip)
2. Read order items (name, quantity, price) until user types "done"
3. Calculate subtotal, apply discount based on customer type, add tax
4. Print a formatted invoice

### Discount Rules
- Regular: 0%
- Premium: 10%
- VIP: 20%

### Tax Rate
- Fixed at 8% (applied after discount)

## What to Look For

The current code has several issues that violate SOLID principles:

### Single Responsibility Principle (SRP)
The code handles multiple concerns in one place:
- Reading user input
- Validating input
- Calculating totals and discounts
- Formatting and printing output

### Open/Closed Principle (OCP)
Adding a new customer type (e.g., "gold" with 15% discount) requires modifying the existing if/else chain.

### Dependency Inversion Principle (DIP)
The code depends directly on `Console` for input/output. This makes it impossible to:
- Unit test the calculation logic
- Reuse the logic with different input sources (file, API, etc.)

## Suggested Structure After Refactoring

```
Console/
├── Models/
│   └── OrderItem.cs
├── Services/
│   ├── IDiscountCalculator.cs
│   └── DiscountCalculator.cs
├── IO/
│   ├── IInputReader.cs
│   ├── IInvoicePrinter.cs
│   ├── ConsoleInputReader.cs
│   └── InvoicePrinter.cs
└── Program.cs
```

## Unit Tests

A test project is provided in `Console.Tests/`. The tests are written against interfaces defined in `Interfaces/`:

- `IDiscountCalculator` - Discount calculation by customer type
- `ITaxCalculator` - Tax calculation
- `IInvoiceCalculator` - Full invoice calculation

### Running Tests
```bash
cd ../Console.Tests
dotnet test
```

**Note:** Tests will fail initially because the implementations are set to `null!`. After you implement the interfaces, update the test files to use your implementations:

```csharp
// Before (in test files):
private readonly IDiscountCalculator _calculator = null!;

// After:
private readonly IDiscountCalculator _calculator = new DiscountCalculator();
```

## Evaluation Criteria
- Code compiles and runs correctly
- All unit tests pass
- Clear separation of concerns
- Meaningful class and method names
- Easy to extend (e.g., adding new customer types)
- Testable design (dependencies can be mocked)

Good luck!
