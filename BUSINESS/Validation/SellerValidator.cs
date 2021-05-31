using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class SellerValidator : AbstractValidator<SellerDTO>
    {
        public SellerValidator()
        {
            RuleFor(seller => seller.Contacts).NotEmpty();
        }
    }
}

