using Microsoft.AspNetCore.Mvc;

namespace Sale.Application.Exception.Customers
{
    public class CustomerCustomDetails: ProblemDetails
    {
        public string AdditionalInfo { get; set; }
    }
}
