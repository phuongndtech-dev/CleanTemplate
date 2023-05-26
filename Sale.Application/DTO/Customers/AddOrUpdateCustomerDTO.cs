namespace Sale.Application.DTO.Customers
{
    public class AddOrUpdateCustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
    }
}