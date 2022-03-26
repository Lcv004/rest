namespace Rest.Models;
public record OrderDetail(long Id, long OrderId, long ProductId, uint Quantity);
