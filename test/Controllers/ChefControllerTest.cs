using Entities;
using Moq;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class ChefControllerTest
{
    private readonly Mock<IChefRepository> _mockChefRepo;

    public ChefControllerTest()
    {
        _mockChefRepo = new Mock<IChefRepository>();
    }

    [Fact]
    public void Add_OneChef_VerifyAddCallOnce()
    {
        // Given
        var chef = ChefFixtures.BuildChef();
        _mockChefRepo.Setup(m => m.Add(It.IsAny<Chef>())).Verifiable();
        var chefController = new ChefController(_mockChefRepo.Object);

        // When
        chefController.Add(chef);

        // Then
        _mockChefRepo.Verify(m => m.Add(It.IsAny<Chef>()), Times.Once);
    }

    [Fact]
    public void Remove_OneChef_VerifyRemoveCallOnce()
    {
        // Given
        _mockChefRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var chefController = new ChefController(_mockChefRepo.Object);

        // When
        chefController.Remove(1);

        // Then
        _mockChefRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneChef_VerifyGetCall()
    {
        // Given
        var chef = ChefFixtures.BuildChef();
        _mockChefRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(chef)
        .Verifiable();

        var chefController = new ChefController(_mockChefRepo.Object);

        // When
        var result = chefController.Get(1);

        // Then
        Assert.Equal<Chef>(chef, result);
        _mockChefRepo.Verify();
    }

    [Fact]
    public void GetAll_Chefs_VerifyGetAllCall()
    {
        // Given
        var chefs = ChefFixtures.BuildChefs(3);
        _mockChefRepo.Setup(m => m.GetAll())
        .Returns(chefs)
        .Verifiable();

        var chefController = new ChefController(_mockChefRepo.Object);

        // When
        var result = chefController.GetAll();

        // Then
        Assert.Equal<Chef>(chefs, result);
        _mockChefRepo.Verify();
    }

    [Fact]
    public void Count_ThreeChefs_VerifyCountCall()
    {
        // Given
        _mockChefRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var chefController = new ChefController(_mockChefRepo.Object);

        // When
        var result = chefController.Count();

        // Then
        Assert.Equal(3, result);
        _mockChefRepo.Verify();
    }
}
