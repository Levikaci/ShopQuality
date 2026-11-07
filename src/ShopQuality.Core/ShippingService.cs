namespace ShopQuality.Core;

public sealed class ShippingService
{
    public decimal Calculate(decimal orderTotal, decimal weightKg, bool remoteRegion)
    {
        if (orderTotal < 0m)
            throw new ArgumentOutOfRangeException(nameof(orderTotal));
        if (weightKg <= 0m)
            throw new ArgumentOutOfRangeException(nameof(weightKg));

        if (orderTotal >= 5000m && !remoteRegion)
            return 0m;

        decimal price = weightKg <= 1m ? 200m : weightKg <= 5m ? 350m : 600m;
        if (remoteRegion)
            price += 300m;
        return price;
    }
}
