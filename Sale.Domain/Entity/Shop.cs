namespace Sale.Domain.Entity
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
