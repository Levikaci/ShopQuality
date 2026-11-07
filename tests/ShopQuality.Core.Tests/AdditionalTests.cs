using ShopQuality.Core;

namespace ShopQuality.Core.Tests;

public class AdditionalTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(100, 0)]
    public void Calculate_InvalidItem_ThrowsArgumentException(int price, int quantity)
    {
        var service = new OrderPricingService();
        Assert.Throws<ArgumentException>(() => service.Calculate(new PriceRequest(
            [new OrderItem(price, quantity)], CustomerTier.Regular, null)));
    }

    [Theory]
    [InlineData(CustomerTier.Silver, null, 50)]
    [InlineData(CustomerTier.Silver, "summer", 100)]
    [InlineData(CustomerTier.Gold, "SUMMER", 150)]
    public void Calculate_TierAndCoupon_ReturnsExpectedDiscount(CustomerTier tier, string? coupon, int expected)
    {
        var result = new OrderPricingService().Calculate(new PriceRequest(
            [new OrderItem(500m, 1), new OrderItem(250m, 2)], tier, coupon));
        Assert.Equal(1000m, result.Subtotal);
        Assert.Equal(expected, result.Discount);
    }

    [Theory]
    [InlineData(900, 1.5, false, 350)]
    [InlineData(900, 5.5, false, 600)]
    [InlineData(4999.99, 1, false, 200)]
    [InlineData(5000, 1, true, 500)]
    public void Calculate_ReturnsExpectedShippingRate(decimal total, decimal weight, bool remote, int expected)
    {
        Assert.Equal(expected, new ShippingService().Calculate(total, weight, remote));
    }
}
