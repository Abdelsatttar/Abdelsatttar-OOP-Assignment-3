namespace RefactoringLab;

public class FedExShippingCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal CalculateCost(decimal weightKg) => weightKg * 15m;
}
