using Xunit;
using Moq;
using Services;
using Entities;
using Utils.Test;
namespace Controllers.Test;

public class ProductControllerTest
{
    [Fact]
    public void Add_OneProduct_ShouldCallRepositoryAddMethod()
    {
        // Given
        Mock<ProductRepository> productRepo = new Mock<ProductRepository>();
        var product = ProductFixtures.BuildProduct();
        productRepo.Setup(m => m.Add(product)).Verifiable();
        var productController = new ProductController((ProductRepository)productRepo.Object);

        // When
        productController.Add(product);

        // Then
        productRepo.VerifyAll();
    }
}
