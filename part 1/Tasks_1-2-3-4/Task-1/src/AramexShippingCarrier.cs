namespace RefactoringLab;

public class AramexShippingCarrier : IShippingCarrier
{
    public string Name => "Aramex";

    public decimal CalculateCost(decimal weightKg) => weightKg * 12m;
}
