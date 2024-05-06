using FluentValidation;
using TaxReporter.DTOs.Invoice;

namespace TaxReporter.Validators.Invoice
{
    public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoice>
    {
        public UpdateInvoiceValidator() 
        {
            RuleFor(invoice => invoice.UserId)
                    .NotNull().WithMessage("UserId is required.");

            RuleFor(invoice => invoice.BusinessName)
                .NotEmpty().WithMessage("Business name is required.")
                .MaximumLength(50).WithMessage("Business name cannot exceed 50 characters.");

            RuleFor(invoice => invoice.Rnc)
                .NotEmpty().WithMessage("RNC is required.")
                .Matches(@"^[0-9]*$").WithMessage("RNC must contain only numbers.");

            RuleFor(invoice => invoice.Nfc)
                .NotEmpty().WithMessage("NFC is required.")
                .Matches(@"^[0-9]*$").WithMessage("NFC must contain only numbers.");

            RuleFor(invoice => invoice.AmountWithoutItbis)
                .NotNull().WithMessage("Amount without ITBIS is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount without ITBIS must be greater than or equal to 0.00");

            RuleFor(invoice => invoice.Itbis)
                .NotNull().WithMessage("ITBIS is required.")
                .GreaterThanOrEqualTo(0).WithMessage("ITBIS must be greater than or equal to 0.00");

            RuleFor(invoice => invoice.ServicePercentage)
                .NotNull().WithMessage("Service percentage is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Service percentage must be greater than or equal to 0.00");

            RuleFor(invoice => invoice.TotalAmount)
                .NotNull().WithMessage("Total amount is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Total amount must be greater than or equal to 0.00");

            RuleFor(invoice => invoice.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .MaximumLength(50).WithMessage("Image URL cannot exceed 50 characters.");

        }

    }

}
