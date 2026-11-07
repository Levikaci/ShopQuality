namespace ShopQuality.Core;

public sealed class OrderPricingService
{
    // Правила предметной области приведены в docs/requirements.md.
    public PriceResult Calculate(PriceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.Items);
        if (request.Items.Count == 0)
            throw new ArgumentException("Заказ должен содержать товары.", nameof(request));

        decimal subtotal = 0m;
        foreach (var item in request.Items)
        {
            if (item.UnitPrice <= 0m || item.Quantity <= 0)
                throw new ArgumentException("Цена и количество должны быть положительными.", nameof(request));
            subtotal += item.UnitPrice * item.Quantity;
        }

        decimal discountRate = request.Tier switch
        {
            CustomerTier.Regular => 0m,
            CustomerTier.Silver => 0.05m,
            CustomerTier.Gold => 0.10m,
            _ => throw new ArgumentOutOfRangeException(nameof(request), "Неизвестный уровень клиента.")
        };

        // Купон SUMMER добавляет 5 процентных пунктов к скидке уровня.
        if (string.Equals(request.Coupon, "SUMMER", StringComparison.OrdinalIgnoreCase))
            discountRate += 0.05m;

        // Общая скидка ограничена 15%.
        discountRate = Math.Min(discountRate, 0.15m);
        decimal discount = Math.Round(subtotal * discountRate, 2, MidpointRounding.AwayFromZero);
        return new PriceResult(subtotal, discount, subtotal - discount);
    }
}
