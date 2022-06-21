namespace Entities;

public class OrderDetail
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public uint Quantity { get; set; }

    public OrderDetail(long id, long orderId, long productId, uint quantity)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }
}
