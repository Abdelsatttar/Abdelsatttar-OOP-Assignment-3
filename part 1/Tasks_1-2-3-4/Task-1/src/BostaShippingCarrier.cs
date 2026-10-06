namespace RefactoringLab;

public class BostaShippingCarrier : IShippingCarrier
{
    public string Name => "Bosta";

    public decimal CalculateCost(decimal weightKg) => weightKg * 10m;
}
