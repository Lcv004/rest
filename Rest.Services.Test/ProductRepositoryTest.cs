using Xunit;
using Rest.Models;
using Rest.Services.Test.Utils.Fixtures;
using System.Collections.Generic;
using System.Linq;

namespace Rest.Services.Test;

public class ProductRepositoryTest
{
    [Fact]
    public void Add_OneProduct_ShouldCountOneProduct()
    {
        var productRepository = new ProductRepository();
        var product = ProductFixtures.BuildProduct();
        productRepository.Add(product);

        Assert.Equal(1, productRepository.Count());
    }

    [Fact]
    public void Remove_OneProduct_ShouldCountOneProducts()
    {
        var productRepository = new ProductRepository();
        var products = ProductFixtures.BuildProducts(2);
        productRepository.Add(products[0]);
        productRepository.Add(products[1]);

        productRepository.Remove(1);

        Assert.Equal(1, productRepository.Count());
    }

    [Fact]
    public void Get_OneProduct_ShouldReturnOneProduct()
    {
        var productRepository = new ProductRepository();
        var product = ProductFixtures.BuildProduct();
        productRepository.Add(product);

        var result = productRepository.Get(1);

        Assert.Equal(product, result);
    }

    [Fact]
    public void Get_NoProduct_ShouldReturnKeyNotFoundException()
    {
        var productRepository = new ProductRepository();

        Assert.Throws<KeyNotFoundException>(() => productRepository.Get(2));
    }

    [Fact]
    public void GetAll_Products_ShouldReturnThreeProducts()
    {
        var productRepository = new ProductRepository();
        var products = ProductFixtures.BuildProducts(3);
        productRepository.Add(products[0]);
        productRepository.Add(products[1]);
        productRepository.Add(products[2]);

        var result = productRepository.GetAll();

        Assert.Equal(products.Count(), result.Count());
        Assert.Equal<Product>(products, result);
    }
}
