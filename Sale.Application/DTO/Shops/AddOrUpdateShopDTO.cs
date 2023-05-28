using FluentValidation;

namespace Sale.Application.DTO.Shops
{
    public class AddOrUpdateShopDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class AddOrUpdateShopValidator : AbstractValidator<AddOrUpdateShopDTO>
    {
        public AddOrUpdateShopValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required");
        }
    }
}
