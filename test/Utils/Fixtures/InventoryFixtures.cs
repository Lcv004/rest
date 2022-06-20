using Entities;
namespace Utils.Test;

public class InventoryFixtures
{
    public static Inventory BuildInventory(long id = 1, long productID = 1, uint quantity = 1)
    {
        var inventory = new Inventory(id, productID, quantity);
        return inventory;
    }

    public static List<Inventory> BuildInventories(uint count)
    {
        var inventories = new List<Inventory>();
        for (var i = 1; i <= count; i++)
        {
            inventories.Add(BuildInventory(i, i, (uint)i));
        }

        return inventories;
    }
}
