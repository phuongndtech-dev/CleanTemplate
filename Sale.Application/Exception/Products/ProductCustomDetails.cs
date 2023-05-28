using Microsoft.AspNetCore.Mvc;

namespace Sale.Application.Exception.Products
{
    public class ProductCustomDetails: ProblemDetails
    {
        public string AdditionalInfo { get; set; }
    }
}
