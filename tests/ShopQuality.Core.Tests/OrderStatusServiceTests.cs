using ShopQuality.Core;

namespace ShopQuality.Core.Tests;

public class OrderStatusServiceTests
{
    [Fact]
    public void ChangeStatus_FromNewToPaid_IsAllowed()
    {
        var result = new OrderStatusService().ChangeStatus(OrderStatus.New, OrderStatus.Paid);
        Assert.Equal(OrderStatus.Paid, result);
    }
}
