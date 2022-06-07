using Xunit;
using FakeItEasy;
using Services;
using Entities;
using Utils.Test;
namespace Controllers.Test;

public class ProductControllerIntegrationTest
{
    private ProductRepository _productRepository;
    private IProductRepository _mockProductRepo;

    public ProductControllerIntegrationTest()
    {
        _productRepository = new ProductRepository();
        _mockProductRepo = A.Fake<IProductRepository>(x => x.Wrapping(_productRepository));
    }

    [Fact]
    public void Add_OneProduct_ShouldReturnProductIdIncrementAndVerifyAddCallOnce()
    {
        // Given
        var product = ProductFixtures.BuildProduct(0);
        var productController = new ProductController(_mockProductRepo);

        // When
        Assert.Equal(0, _mockProductRepo.Count());
        productController.Add(product);

        //Then
        Assert.Equal(1, _mockProductRepo.Get(1).Id);
        A.CallTo(() => _mockProductRepo.Add(product)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Remove_OneProduct_ShouldReturnProductCountDecreasedAndVerifyRemoveCallOnce()
    {
        // Given
        var product = ProductFixtures.BuildProducts(2);
        var productController = new ProductController(_mockProductRepo);
        productController.Add(product[0]);
        productController.Add(product[1]);

        // When
        Assert.Equal(2, _mockProductRepo.Count());
        productController.Remove(1);

        // Then
        A.CallTo(() => _mockProductRepo.Remove(1)).MustHaveHappenedOnceExactly();
        Assert.Equal(1, _mockProductRepo.Count());
    }

    [Fact]
    public void Get_OneProduct_ShouldReturnProductAndVerifyGetCall()
    {
        // Given
        var product = ProductFixtures.BuildProduct();
        var productController = new ProductController(_mockProductRepo);
        productController.Add(product);

        // When
        var result = productController.Get(1);

        // Then
        Assert.Equal<Product>(product, result);
        A.CallTo(() => _mockProductRepo.Get(1)).MustHaveHappened();
    }

    [Fact]
    public void GetAll_Products_ShouldReturnProductsAndVerifyGetAllCall()
    {
        // Given
        var products = ProductFixtures.BuildProducts(3);
        var productController = new ProductController(_mockProductRepo);
        productController.Add(products[0]);
        productController.Add(products[1]);
        productController.Add(products[2]);

        // When
        var result = productController.GetAll();

        // Then
        Assert.Equal<Product>(products, result);
        A.CallTo(() => _mockProductRepo.GetAll()).MustHaveHappened();
    }
}
