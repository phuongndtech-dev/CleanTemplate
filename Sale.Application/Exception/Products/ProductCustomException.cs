namespace Sale.Application.Exception.Products
{
    public class ProductCustomException : System.Exception
    {
        public string AdditionalInfo { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public ProductCustomException(string instance)
        {
            Type = "product-custom-exception";
            Detail = "There was an unexpected error while fetching the product.";
            Title = "Custom Product Exception";
            AdditionalInfo = "Maybe you can try again in a bit?";
            Instance = instance;
        }
    }
}
