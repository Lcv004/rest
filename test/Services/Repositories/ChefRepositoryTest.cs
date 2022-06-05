using Xunit;
using Entities;
using System.Collections.Generic;
using System.Linq;
using Utils.Test;
namespace Services.Test;

public class ChefRepositoryTest
{
    [Fact]
    public void Add_OneChef_ShouldCountOneChef()
    {
        var chefRepository = new ChefRepository();
        var chef = ChefFixtures.BuildChef();
        chefRepository.Add(chef);

        Assert.Equal(1, chefRepository.Count());
    }

    [Fact]
    public void Remove_OneChef_ShouldCountOneChefs()
    {
        var chefRepository = new ChefRepository();
        var chefs = ChefFixtures.BuildChefs(2);
        chefRepository.Add(chefs[0]);
        chefRepository.Add(chefs[1]);

        chefRepository.Remove(1);

        Assert.Equal(1, chefRepository.Count());
    }

    [Fact]
    public void Get_OneChef_ShouldReturnOneChef()
    {
        var chefRepository = new ChefRepository();
        var chef = ChefFixtures.BuildChef();
        chefRepository.Add(chef);

        var result = chefRepository.Get(1);

        Assert.Equal(chef, result);
    }

    [Fact]
    public void Get_NoChef_ShouldReturnKeyNotFoundException()
    {
        var chefRepository = new ChefRepository();

        Assert.Throws<KeyNotFoundException>(() => chefRepository.Get(2));
    }

    [Fact]
    public void GetAll_Chefs_ShouldReturnThreeChefs()
    {
        var chefRepository = new ChefRepository();
        var chefs = ChefFixtures.BuildChefs(3);
        chefRepository.Add(chefs[0]);
        chefRepository.Add(chefs[1]);
        chefRepository.Add(chefs[2]);

        var result = chefRepository.GetAll();

        Assert.Equal(chefs.Count(), result.Count());
        Assert.Equal<Chef>(chefs, result);
    }
}
