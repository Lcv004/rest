using Xunit;
using Moq;
using Services;
using Entities;
using Utils.Test;
using System.Collections.Generic;
namespace Controllers.Test;

public class ProductControllerTest
{
    [Fact]
    public void Add_OneProduct_VerifyAddCallOnce()
    {
        // Given
        var product = ProductFixtures.BuildProduct();
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(m => m.Add(It.IsAny<Product>())).Verifiable();
        var productController = new ProductController(mockProductRepo.Object);

        // When
        productController.Add(product);

        // Then
        mockProductRepo.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void Remove_OneProduct_VerifyRemoveCallOnce()
    {
        // Given
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var productController = new ProductController(mockProductRepo.Object);

        // When
        productController.Remove(1);

        // Then
        mockProductRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneProduct_VerifyGetCall()
    {
        // Given
        var product = ProductFixtures.BuildProduct();
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(product)
        .Verifiable();

        var productController = new ProductController(mockProductRepo.Object);

        // When
        var result = productController.Get(1);

        // Then
        Assert.Equal<Product>(product, result);
        mockProductRepo.Verify();
    }

    [Fact]
    public void GetAll_Products_VerifyGetAllCall()
    {
        // Given
        var products = ProductFixtures.BuildProducts(3);
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(m => m.GetAll())
        .Returns(products)
        .Verifiable();

        var productController = new ProductController(mockProductRepo.Object);

        // When
        var result = productController.GetAll();

        // Then
        Assert.Equal<Product>(products, result);
        mockProductRepo.Verify();
    }

    [Fact]
    public void Count_ThreeProducts_VerifyCountCall()
    {
        // Given
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var productController = new ProductController(mockProductRepo.Object);

        // When
        var result = productController.Count();

        // Then
        Assert.Equal(3, result);
        mockProductRepo.Verify();
    }
}
