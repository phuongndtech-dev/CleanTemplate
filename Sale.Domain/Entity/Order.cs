namespace Sale.Domain.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public bool Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Shop Shops { get; set; }
        public virtual Product Products { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
