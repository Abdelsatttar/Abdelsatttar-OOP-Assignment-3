namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }
    decimal CalculateCost(decimal weightKg);
}
