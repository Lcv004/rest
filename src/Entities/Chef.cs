namespace Entities;

public class Chef
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int Experience { get; set; }

    public Chef(long id, string name, int experience)
    {
        Id = id;
        Name = name;
        Experience = experience;
    }
}
