using Entities;
using System.Collections.Generic;
namespace Utils.Test;

public class ChefFixtures
{
    public static Chef BuildChef(long id = 1, string name = "chef", int experience = 1)
    {
        var chef = new Chef(id, name, experience);
        return chef;
    }

    public static List<Chef> BuildChefs(uint count)
    {
        List<Chef> chefs = new List<Chef>();
        for (int i = 1; i <= count; i++)
        {
            chefs.Add(BuildChef(i, "Chef " + i, i));
        }

        return chefs;
    }
}
