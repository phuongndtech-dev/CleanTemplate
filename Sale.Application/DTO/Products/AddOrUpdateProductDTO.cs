using FluentValidation;

namespace Sale.Application.DTO.Products
{
    public class AddOrUpdateProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class AddOrUpdateProductValidator : AbstractValidator<AddOrUpdateProductDTO>
    {
        public AddOrUpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Prices is required");
        }
    }
}
