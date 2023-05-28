namespace Sale.Application.Exception.Customers
{
    public class CustomerCustomException : System.Exception
    {
        public string AdditionalInfo { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public CustomerCustomException(string instance)
        {
            Type = "customer-custom-exception";
            Detail = "There was an unexpected error while fetching the product.";
            Title = "Custom customer Exception";
            AdditionalInfo = "Maybe you can try again in a bit?";
            Instance = instance;
        }
    }
}
