using ShopQuality.Core;

namespace ShopQuality.Core.Tests;

public class ShippingServiceTests
{
    private readonly ShippingService _service = new();

    [Fact]
    public void Calculate_StandardRegionWithHighTotal_ReturnsFreeShipping()
    {
        Assert.Equal(0m, _service.Calculate(5000m, 2m, false));
    }

    [Fact]
    public void Calculate_StandardRegionWithLightParcel_ReturnsBaseRate()
    {
        Assert.Equal(200m, _service.Calculate(900m, 1m, false));
    }
}
