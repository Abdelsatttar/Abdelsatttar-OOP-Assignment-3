namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly Dictionary<string, IShippingCarrier> _carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        _carriers = carriers.ToDictionary(
            carrier => carrier.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!_carriers.TryGetValue(carrier, out var shippingCarrier))
            throw new ArgumentException($"Unknown carrier: {carrier}");

        return shippingCarrier.CalculateCost(weightKg);
    }
}
