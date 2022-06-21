namespace Entities;

public class Order
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public string? Status { get; set; }

    public Order(long id, long customerId, string status)
    {
        Id = id;
        CustomerId = customerId;
        Status = status;
    }
}
