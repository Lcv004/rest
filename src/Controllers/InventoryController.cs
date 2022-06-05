using Entities;
using Services;
namespace Controllers;
public class InventoryController
{
    private IInventoryRepository _inventoryRepository;

    public InventoryController(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public void Add(Inventory inventory)
    {
        _inventoryRepository.Add(inventory);
    }

    public void Remove(long key)
    {
        _inventoryRepository.Remove(key);
    }

    public Inventory Get(long key)
    {
        return _inventoryRepository.Get(key);
    }

    public IEnumerable<Inventory> GetAll()
    {
        return _inventoryRepository.GetAll();
    }

    public int Count()
    {
        return _inventoryRepository.Count();
    }
}
