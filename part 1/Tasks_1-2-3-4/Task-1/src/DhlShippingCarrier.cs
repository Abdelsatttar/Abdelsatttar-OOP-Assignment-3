namespace RefactoringLab;

public class DhlShippingCarrier : IShippingCarrier
{
    public string Name => "DHL";

    public decimal CalculateCost(decimal weightKg) => weightKg * 18m;
}
