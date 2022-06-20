using Entities;
using Moq;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class ProductControllerTest
{
    private readonly Mock<IProductRepository> _mockProductRepo;

    public ProductControllerTest()
    {
        _mockProductRepo = new Mock<IProductRepository>();
    }

    [Fact]
    public void Add_OneProduct_VerifyAddCallOnce()
    {
        // Given
        var product = ProductFixtures.BuildProduct();
        _mockProductRepo.Setup(m => m.Add(It.IsAny<Product>())).Verifiable();
        var productController = new ProductController(_mockProductRepo.Object);

        // When
        productController.Add(product);

        // Then
        _mockProductRepo.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void Remove_OneProduct_VerifyRemoveCallOnce()
    {
        // Given
        _mockProductRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var productController = new ProductController(_mockProductRepo.Object);

        // When
        productController.Remove(1);

        // Then
        _mockProductRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneProduct_VerifyGetCall()
    {
        // Given
        var product = ProductFixtures.BuildProduct();
        _mockProductRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(product)
        .Verifiable();

        var productController = new ProductController(_mockProductRepo.Object);

        // When
        var result = productController.Get(1);

        // Then
        Assert.Equal<Product>(product, result);
        _mockProductRepo.Verify();
    }

    [Fact]
    public void GetAll_Products_VerifyGetAllCall()
    {
        // Given
        var products = ProductFixtures.BuildProducts(3);
        _mockProductRepo.Setup(m => m.GetAll())
        .Returns(products)
        .Verifiable();

        var productController = new ProductController(_mockProductRepo.Object);

        // When
        var result = productController.GetAll();

        // Then
        Assert.Equal<Product>(products, result);
        _mockProductRepo.Verify();
    }

    [Fact]
    public void Count_ThreeProducts_VerifyCountCall()
    {
        // Given
        _mockProductRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var productController = new ProductController(_mockProductRepo.Object);

        // When
        var result = productController.Count();

        // Then
        Assert.Equal(3, result);
        _mockProductRepo.Verify();
    }
}
