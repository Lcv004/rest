using Entities;
using System.Collections.Generic;
namespace Utils.Test;

public class InventoryFixtures
{
    public static Inventory BuildInventory(long id = 1, long productID = 1, uint quantity = 1)
    {
        var inventory = new Inventory(id, productID, quantity);
        return inventory;
    }

    public static List<Inventory> BuildInventorys(uint count)
    {
        List<Inventory> inventories = new List<Inventory>();
        for (int i = 1; i <= count; i++)
        {
            inventories.Add(BuildInventory(i, i, (uint)i));
        }

        return inventories;
    }
}
