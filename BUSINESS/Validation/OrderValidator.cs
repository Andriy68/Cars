using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(order => order.CarID).GreaterThan(0);
            RuleFor(order => order.CustomerID).GreaterThan(0);
        }
    }
}

