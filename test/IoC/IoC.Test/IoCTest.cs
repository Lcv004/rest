using Services;
using Controllers;
using IoC;
using Xunit;

namespace IoC.Test;

public class IoCTest
{
    [Fact]
    public void GetInstance_InstanceIsNotNull_ShouldBeNotNull()
    {
        // Given

        // When
        var result = Ioc.GetInstance();
        // Then
        Assert.NotNull(result);
    }

    [Fact]
    public void GetInstance_IsSameInstance_ShouldBeEqual()
    {
        // Given
    
        // When
        var result1 = Ioc.GetInstance();
        var result2 = Ioc.GetInstance();
        // Then
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Get_ObjectInstantiated_ShouldReturnObject()
    {
        // Given
        Ioc.GetInstance();
        // When
        var result = Ioc.Get("ProductRepository");
        // Then
        Assert.NotNull(result);
    }

    [Fact]
    public void Get_ObjectNotInstantiated_ShouldThrowNullException()
    {
        // Given
        Ioc.GetInstance();
        // When
        
        // Then
        Assert.Throws<KeyNotFoundException>(() => Ioc.Get("UnexistentKey"));
    }
}
