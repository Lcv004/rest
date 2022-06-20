using System.Collections.Generic;
using System.Linq;
using Entities;
using Utils.Test;
using Xunit;
namespace Services.Test;

public class InventoryRepositoryTest
{
    [Fact]
    public void Add_OneInventory_ShouldCountOneInventory()
    {
        var inventoryRepository = new InventoryRepository();
        var inventory = InventoryFixtures.BuildInventory();
        inventoryRepository.Add(inventory);

        Assert.Equal(1, inventoryRepository.Count());
    }

    [Fact]
    public void Remove_OneInventory_ShouldCountOneInventorys()
    {
        var inventoryRepository = new InventoryRepository();
        var inventories = InventoryFixtures.BuildInventories(2);
        inventoryRepository.Add(inventories[0]);
        inventoryRepository.Add(inventories[1]);

        inventoryRepository.Remove(1);

        Assert.Equal(1, inventoryRepository.Count());
    }

    [Fact]
    public void Get_OneInventory_ShouldReturnOneInventory()
    {
        var inventoryRepository = new InventoryRepository();
        var inventory = InventoryFixtures.BuildInventory();
        inventoryRepository.Add(inventory);

        var result = inventoryRepository.Get(1);

        Assert.Equal(inventory, result);
    }

    [Fact]
    public void Get_NoInventory_ShouldReturnKeyNotFoundException()
    {
        var inventoryRepository = new InventoryRepository();

        Assert.Throws<KeyNotFoundException>(() => inventoryRepository.Get(2));
    }

    [Fact]
    public void GetAll_Inventorys_ShouldReturnThreeInventorys()
    {
        var inventoryRepository = new InventoryRepository();
        var inventories = InventoryFixtures.BuildInventories(3);
        inventoryRepository.Add(inventories[0]);
        inventoryRepository.Add(inventories[1]);
        inventoryRepository.Add(inventories[2]);

        var result = inventoryRepository.GetAll();

        Assert.Equal(inventories.Count(), result.Count());
        Assert.Equal<Inventory>(inventories, result);
    }
}
