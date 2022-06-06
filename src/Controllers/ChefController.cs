using Entities;
using Services;
namespace Controllers;
public class ChefController
{
    private IChefRepository _chefRepository;

    public ChefController(IChefRepository chefRepository)
    {
        _chefRepository = chefRepository;
    }

    public void Add(Chef chef)
    {
        _chefRepository.Add(chef);
    }

    public void Remove(long key)
    {
        _chefRepository.Remove(key);
    }

    public Chef Get(long key)
    {
        return _chefRepository.Get(key);
    }

    public IEnumerable<Chef> GetAll()
    {
        return _chefRepository.GetAll();
    }

    public int Count()
    {
        return _chefRepository.Count();
    }
}
