using Xunit;
using FakeItEasy;
using Services;
using Entities;
using Utils.Test;
namespace Controllers.Test;

public class InventoryControllerIntegrationTest
{
    private InventoryRepository _inventoryRepository;
    private IInventoryRepository _mockInventoryRepo;

    public InventoryControllerIntegrationTest()
    {
        _inventoryRepository = new InventoryRepository();
        _mockInventoryRepo = A.Fake<IInventoryRepository>(x => x.Wrapping(_inventoryRepository));
    }

    [Fact]
    public void Add_OneInventory_ShouldReturnInventoryIdIncrementAndVerifyAddCallOnce()
    {
        // Given
        var inventory = InventoryFixtures.BuildInventory(0);
        var inventoryController = new InventoryController(_mockInventoryRepo);

        // When
        Assert.Equal(0, _mockInventoryRepo.Count());
        inventoryController.Add(inventory);

        //Then
        Assert.Equal(1, _mockInventoryRepo.Get(1).Id);
        A.CallTo(() => _mockInventoryRepo.Add(inventory)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Remove_OneInventory_ShouldReturnInventoryCountDecreasedAndVerifyRemoveCallOnce()
    {
        // Given
        var inventory = InventoryFixtures.BuildInventories(2);
        var inventoryController = new InventoryController(_mockInventoryRepo);
        inventoryController.Add(inventory[0]);
        inventoryController.Add(inventory[1]);

        // When
        Assert.Equal(2, _mockInventoryRepo.Count());
        inventoryController.Remove(1);

        // Then
        A.CallTo(() => _mockInventoryRepo.Remove(1)).MustHaveHappenedOnceExactly();
        Assert.Equal(1, _mockInventoryRepo.Count());
    }

    [Fact]
    public void Get_OneInventory_ShouldReturnInventoryAndVerifyGetCall()
    {
        // Given
        var inventory = InventoryFixtures.BuildInventory();
        var inventoryController = new InventoryController(_mockInventoryRepo);
        inventoryController.Add(inventory);

        // When
        var result = inventoryController.Get(1);

        // Then
        Assert.Equal<Inventory>(inventory, result);
        A.CallTo(() => _mockInventoryRepo.Get(1)).MustHaveHappened();
    }

    [Fact]
    public void GetAll_Inventories_ShouldReturnInventoriesAndVerifyGetAllCall()
    {
        // Given
        var inventories = InventoryFixtures.BuildInventories(3);
        var inventoryController = new InventoryController(_mockInventoryRepo);
        inventoryController.Add(inventories[0]);
        inventoryController.Add(inventories[1]);
        inventoryController.Add(inventories[2]);

        // When
        var result = inventoryController.GetAll();

        // Then
        Assert.Equal<Inventory>(inventories, result);
        A.CallTo(() => _mockInventoryRepo.GetAll()).MustHaveHappened();
    }
}
