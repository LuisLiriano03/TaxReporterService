using FluentValidation;
using TaxReporter.DTOs.Invoice;

namespace TaxReporter.Validators.Invoice
{
    public class UpdateStateInvoiceValidator : AbstractValidator<UpdateState>
    {
        public UpdateStateInvoiceValidator() 
        { 
            RuleFor(state => state.StateId)
                .NotEmpty().WithMessage("The state ID is required")
                .InclusiveBetween(1, 3).WithMessage("The state must be between 1 and 4");

        }

    }

}
