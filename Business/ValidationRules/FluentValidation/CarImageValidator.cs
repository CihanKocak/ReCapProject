﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarId).NotNull();
            RuleFor(p => p.CarId).NotEmpty();
            //RuleFor(p => p.ImagePath).NotEmpty();
        }
    }
}