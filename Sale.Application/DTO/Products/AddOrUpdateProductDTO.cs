using FluentValidation;

namespace Sale.Application.DTO.Products
{
    public class AddOrUpdateProductDTO
    {
    }

    public class AddOrUpdateProductValidator : AbstractValidator<AddOrUpdateProductDTO>
    {
        public AddOrUpdateProductValidator()
        {
           
        }
    }
}
