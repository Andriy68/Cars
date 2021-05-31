using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.NameSurname).NotEmpty();
            RuleFor(customer => customer.Contacts).NotEmpty();
        }
    }
}

