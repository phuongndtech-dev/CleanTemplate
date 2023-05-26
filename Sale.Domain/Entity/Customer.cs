namespace Sale.Domain.Entity
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }

        public virtual Product Product { get; set; }
    }
}
