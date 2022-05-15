namespace Entities;
public record OrderDetail(long Id, long OrderId, long ProductId, uint Quantity);
