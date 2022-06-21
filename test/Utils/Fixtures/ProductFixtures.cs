using Entities;
namespace Utils.Test;

public class ProductFixtures
{
    public static Product BuildProduct(long id = 1, string name = "product", int difficulty = 1)
    {
        var product = new Product(id, name, difficulty);
        return product;
    }

    public static List<Product> BuildProducts(uint count)
    {
        var products = new List<Product>();
        for (var i = 1; i <= count; i++)
        {
            products.Add(BuildProduct(i, "Product " + i, i));
        }

        return products;
    }
}
