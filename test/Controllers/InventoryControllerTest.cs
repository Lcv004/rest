using Entities;
using Moq;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class InventoryControllerTest
{
    private readonly Mock<IInventoryRepository> _mockInventoryRepo;

    public InventoryControllerTest()
    {
        _mockInventoryRepo = new Mock<IInventoryRepository>();
    }

    [Fact]
    public void Add_OneInventory_VerifyAddCallOnce()
    {
        // Given
        var inventory = InventoryFixtures.BuildInventory();
        _mockInventoryRepo.Setup(m => m.Add(It.IsAny<Inventory>())).Verifiable();
        var inventoryController = new InventoryController(_mockInventoryRepo.Object);

        // When
        inventoryController.Add(inventory);

        // Then
        _mockInventoryRepo.Verify(m => m.Add(It.IsAny<Inventory>()), Times.Once);
    }

    [Fact]
    public void Remove_OneInventory_VerifyRemoveCallOnce()
    {
        // Given
        _mockInventoryRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var inventoryController = new InventoryController(_mockInventoryRepo.Object);

        // When
        inventoryController.Remove(1);

        // Then
        _mockInventoryRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneInventory_VerifyGetCall()
    {
        // Given
        var inventory = InventoryFixtures.BuildInventory();
        _mockInventoryRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(inventory)
        .Verifiable();

        var inventoryController = new InventoryController(_mockInventoryRepo.Object);

        // When
        var result = inventoryController.Get(1);

        // Then
        Assert.Equal<Inventory>(inventory, result);
        _mockInventoryRepo.Verify();
    }

    [Fact]
    public void GetAll_Inventorys_VerifyGetAllCall()
    {
        // Given
        var inventories = InventoryFixtures.BuildInventories(3);
        _mockInventoryRepo.Setup(m => m.GetAll())
        .Returns(inventories)
        .Verifiable();

        var inventoryController = new InventoryController(_mockInventoryRepo.Object);

        // When
        var result = inventoryController.GetAll();

        // Then
        Assert.Equal<Inventory>(inventories, result);
        _mockInventoryRepo.Verify();
    }

    [Fact]
    public void Count_ThreeInventorys_VerifyCountCall()
    {
        // Given
        _mockInventoryRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var inventoryController = new InventoryController(_mockInventoryRepo.Object);

        // When
        var result = inventoryController.Count();

        // Then
        Assert.Equal(3, result);
        _mockInventoryRepo.Verify();
    }
}
