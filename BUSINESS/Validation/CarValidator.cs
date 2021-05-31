using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class CarValidator : AbstractValidator<CarDTO>
    {
        public CarValidator()
        {
            RuleFor(car => car.Price).GreaterThan(0).NotNull();
            RuleFor(car => car.SellerID).GreaterThan(0).NotNull();
        }
    }
}
