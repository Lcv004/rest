namespace Entities;

public class Product
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int Difficulty { get; set; }

    public Product(long id, string name, int difficulty)
    {
        Id = id;
        Name = name;
        Difficulty = difficulty;
    }
}
