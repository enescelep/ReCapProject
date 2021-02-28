using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalManager : AbstractValidator<Rental>
    {
        public RentalManager()
        {
            RuleFor(r => r.CarID).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentalId).NotEmpty();
        }
    }
}
