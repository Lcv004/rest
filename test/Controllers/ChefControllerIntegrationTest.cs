using Entities;
using FakeItEasy;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class ChefControllerIntegrationTest
{
    private readonly ChefRepository _chefRepository;
    private readonly IChefRepository _mockChefRepo;

    public ChefControllerIntegrationTest()
    {
        _chefRepository = new ChefRepository();
        _mockChefRepo = A.Fake<IChefRepository>(x => x.Wrapping(_chefRepository));
    }

    [Fact]
    public void Add_OneChef_ShouldReturnChefIdIncrementAndVerifyAddCallOnce()
    {
        // Given
        var chef = ChefFixtures.BuildChef(0);
        var chefController = new ChefController(_mockChefRepo);

        // When
        Assert.Equal(0, _mockChefRepo.Count());
        chefController.Add(chef);

        //Then
        Assert.Equal(1, _mockChefRepo.Get(1).Id);
        A.CallTo(() => _mockChefRepo.Add(chef)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Remove_OneChef_ShouldReturnChefCountDecreasedAndVerifyRemoveCallOnce()
    {
        // Given
        var chef = ChefFixtures.BuildChefs(2);
        var chefController = new ChefController(_mockChefRepo);
        chefController.Add(chef[0]);
        chefController.Add(chef[1]);

        // When
        Assert.Equal(2, _mockChefRepo.Count());
        chefController.Remove(1);

        // Then
        A.CallTo(() => _mockChefRepo.Remove(1)).MustHaveHappenedOnceExactly();
        Assert.Equal(1, _mockChefRepo.Count());
    }

    [Fact]
    public void Get_OneChef_ShouldReturnChefAndVerifyGetCall()
    {
        // Given
        var chef = ChefFixtures.BuildChef();
        var chefController = new ChefController(_mockChefRepo);
        chefController.Add(chef);

        // When
        var result = chefController.Get(1);

        // Then
        Assert.Equal<Chef>(chef, result);
        A.CallTo(() => _mockChefRepo.Get(1)).MustHaveHappened();
    }

    [Fact]
    public void GetAll_Chefs_ShouldReturnChefsAndVerifyGetAllCall()
    {
        // Given
        var chefs = ChefFixtures.BuildChefs(3);
        var chefController = new ChefController(_mockChefRepo);
        chefController.Add(chefs[0]);
        chefController.Add(chefs[1]);
        chefController.Add(chefs[2]);

        // When
        var result = chefController.GetAll();

        // Then
        Assert.Equal<Chef>(chefs, result);
        A.CallTo(() => _mockChefRepo.GetAll()).MustHaveHappened();
    }
}
