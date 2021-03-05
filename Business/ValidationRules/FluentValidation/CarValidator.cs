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
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(50);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(80).When(c => c.CarId == 1);
            //RuleFor(c => c.Description).Must(StartWithCapitalLetter);
        }

        

        //private bool StartWithCapitalLetter(string arg)
        //{

        //    List<string> stringList = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "X", "Y", "Z" };

        //    foreach (var item in stringList)
        //    {
        //        if (arg.Substring(0, 1) == item)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
