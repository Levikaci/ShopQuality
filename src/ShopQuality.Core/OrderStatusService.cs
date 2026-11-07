namespace ShopQuality.Core;

public sealed class OrderStatusService
{
    public OrderStatus ChangeStatus(OrderStatus current, OrderStatus next)
    {
        if (!Enum.IsDefined(current) || !Enum.IsDefined(next))
            throw new ArgumentOutOfRangeException(nameof(next), "Неизвестный статус.");
        if (current == next)
            return current;

        bool allowed = current switch
        {
            OrderStatus.New => next is OrderStatus.Paid or OrderStatus.Cancelled,
            OrderStatus.Paid => next is OrderStatus.Shipped or OrderStatus.Cancelled,
            OrderStatus.Shipped => false,
            OrderStatus.Cancelled => false,
            _ => false
        };

        if (!allowed)
            throw new InvalidOperationException($"Переход {current} -> {next} запрещён.");
        return next;
    }
}
