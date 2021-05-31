using BUSINESS.DTO;
using FluentValidation;

namespace BUSINESS.Validation
{
    public class WorkerValidator : AbstractValidator<WorkerDTO>
    {
        public WorkerValidator()
        {
            RuleFor(worker => worker.NameSurname).NotEmpty();
            RuleFor(worker => worker.Salary).GreaterThan(0);
        }
    }
}

