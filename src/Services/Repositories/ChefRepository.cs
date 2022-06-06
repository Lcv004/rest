using Entities;
namespace Services;
public class ChefRepository : IChefRepository
{
    private Dictionary<long, Chef> _chefDictionary;
    private long _id;

    public ChefRepository()
    {
        _chefDictionary = new Dictionary<long, Chef>();
        _id = 0;
    }

    public void Add(Chef entity)
    {
        _id++;
        entity.Id = _id;
        _chefDictionary.Add(_id, entity);
    }

    public void Remove(long key)
    {
        if (_chefDictionary.ContainsKey(key))
        {
            _chefDictionary.Remove(key);
            // TODO: Change chef status to "removed".
        }
    }

    public Chef Get(long key)
    {
        return _chefDictionary[key];
    }

    public IEnumerable<Chef> GetAll()
    {
        return _chefDictionary.Values;
    }

    public int Count()
    {
        return _chefDictionary.Count;
    }
}
