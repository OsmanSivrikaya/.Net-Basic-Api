using Case.Entity;
using FluentValidation;

namespace Case.Validators.Demands
{
    public class CreateDemandValidator : AbstractValidator<Demand>
    {
        public CreateDemandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(254)
                .WithMessage("254 Karakterden uzun olamaz");
            RuleFor(p => p.Complaint)
               .NotEmpty()
               .NotNull()
               .WithMessage("Boş geçilemez")
               .MaximumLength(400)
               .WithMessage("4000 Karakterden uzun olamaz");
            RuleFor(p => p.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Boş geçilemez")
               .MaximumLength(254)
               .WithMessage("254 Karakterden uzun olamaz");
        }
    }
}
