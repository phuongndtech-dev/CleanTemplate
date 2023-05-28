using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Sale.Application.DTO.Customers
{
    public class AddOrUpdateCustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class AddOrUpdateCustomerValidator : AbstractValidator<AddOrUpdateCustomerDTO>
    {
        public AddOrUpdateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.DOB).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
        }
    }
}