using ShopQuality.Core;

namespace ShopQuality.Core.Tests;

public class OrderPricingServiceTests
{
    private readonly OrderPricingService _service = new();

    [Fact]
    public void Calculate_RegularCustomerWithoutCoupon_ReturnsFullPrice()
    {
        var result = _service.Calculate(new PriceRequest(
            [new OrderItem(100m, 2)], CustomerTier.Regular, null));
        Assert.Equal(200m, result.Total);
        Assert.Equal(0m, result.Discount);
    }

    [Fact]
    public void Calculate_GoldCustomer_UsesTenPercentDiscount()
    {
        var result = _service.Calculate(new PriceRequest(
            [new OrderItem(1000m, 1)], CustomerTier.Gold, null));
        Assert.Equal(100m, result.Discount);
        Assert.Equal(900m, result.Total);
    }

    [Fact]
    public void Calculate_EmptyOrder_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _service.Calculate(
            new PriceRequest([], CustomerTier.Regular, null)));
    }
}
