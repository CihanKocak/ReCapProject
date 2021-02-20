using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Length(3, 15);
            RuleFor(u => u.FirstName).Must(u => HasValidFirstName(u)).WithMessage("The Firstname must only contain letters");
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Length(3, 15);
            RuleFor(u => u.LastName).Must(u => HasValidLastName(u)).WithMessage("The Lastname must only contain letters");
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).Must(u => HasValidPassword(u)).WithMessage("The Password must contain alphanumeric characters");
        }

        private bool HasValidFirstName(string args)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");

            return (lowercase.IsMatch(args) && uppercase.IsMatch(args));
        }
        private bool HasValidLastName(string args)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");

            return (lowercase.IsMatch(args) && uppercase.IsMatch(args));
        }
        private bool HasValidPassword(string args)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(args) && uppercase.IsMatch(args) && digit.IsMatch(args) && symbol.IsMatch(args));
        }
    }
}
