using Microsoft.AspNetCore.Mvc;

namespace Sale.Application.Exception.Shops
{
    public class ShopCustomDetails: ProblemDetails
    {
        public string AdditionalInfo { get; set; }
    }
}
