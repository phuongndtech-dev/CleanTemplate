namespace Sale.Application.Exception.Shops
{
    public class ShopCustomException : System.Exception
    {
        public string AdditionalInfo { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public ShopCustomException(string instance)
        {
            Type = "shop-custom-exception";
            Detail = "There was an unexpected error while fetching the shop.";
            Title = "Custom shop Exception";
            AdditionalInfo = "Maybe you can try again in a bit?";
            Instance = instance;
        }
    }
}
