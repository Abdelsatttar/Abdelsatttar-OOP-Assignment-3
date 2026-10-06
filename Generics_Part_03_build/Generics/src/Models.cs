namespace Generics;

public interface IHasId
{
    int Id { get; }
}

public class Student : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Course : IHasId
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}
