namespace Sale.Domain.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }

        public virtual List<Shop> Shops { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}
