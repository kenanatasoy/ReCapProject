using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).Matches("^[A-Z]*").WithMessage("Description must start with a capital letter");//this must be fixed!!
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(50);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(80).When(c => c.BrandId == 1);
        }

        //Some other possible rule:
        //Character.isUpperCase(line.charAt(0)
    }
}
