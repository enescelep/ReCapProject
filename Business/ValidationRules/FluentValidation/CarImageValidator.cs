using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator <CarImage> 
    {
        public CarImageValidator()
        {
            RuleFor(c => c.ImagePath).Must(a => a.EndsWith(".jpeg") || a.EndsWith(".jpg") || a.EndsWith(".png")).WithMessage("Girilen dosyanın türü desteklenmiyor!");
        }
    }
}
