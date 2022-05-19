using Entities;
namespace Services;

public class InventoryRepository : IInventoryRepository
{
    private Dictionary<long, Inventory> _inventoryDictionary;
    private long _id;

    public InventoryRepository()
    {
        _inventoryDictionary = new Dictionary<long, Inventory>();
        _id = 0;
    }

    public void Add(Inventory entity)
    {
        _id++;
        Inventory newInventory = entity with
        {
            Id = _id,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity
        };
        _inventoryDictionary.Add(_id, newInventory);
    }

    public void Remove(long key)
    {
        if (_inventoryDictionary.ContainsKey(key))
        {
            _inventoryDictionary.Remove(key);
            // TODO: Change inventory status to "removed".
        }
    }

    public Inventory Get(long key)
    {
        return _inventoryDictionary[key];
    }

    public IEnumerable<Inventory> GetAll()
    {
        return _inventoryDictionary.Values;
    }

    public int Count()
    {
        return _inventoryDictionary.Count;
    }
}
