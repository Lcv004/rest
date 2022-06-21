namespace Entities;

public class Inventory
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public uint Quantity { get; set; }

    public Inventory(long id, long productId, uint quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }
}
