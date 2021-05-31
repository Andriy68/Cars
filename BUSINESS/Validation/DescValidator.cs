using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class DescValidator : AbstractValidator<DescDTO>
    {
        public DescValidator()
        {
            RuleFor(desc => desc.Brand).NotEmpty();
            RuleFor(desc => desc.Color).NotEmpty();
            RuleFor(desc => desc.CarID).GreaterThan(0);
        }
    }
}
