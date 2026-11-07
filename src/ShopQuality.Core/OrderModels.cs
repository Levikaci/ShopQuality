namespace ShopQuality.Core;

public enum CustomerTier { Regular, Silver, Gold }
public enum OrderStatus { New, Paid, Shipped, Cancelled }

public sealed record OrderItem(decimal UnitPrice, int Quantity);
public sealed record PriceRequest(IReadOnlyList<OrderItem> Items, CustomerTier Tier, string? Coupon);
public sealed record PriceResult(decimal Subtotal, decimal Discount, decimal Total);
