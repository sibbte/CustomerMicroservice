using CustomerMicroservice.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerMicroservice.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            var telephoneRegex = new Regex(@"^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$");
            var mobRegex = new Regex(@"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$");
            var postcodeRegex = new Regex(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})$");

            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).MinimumLength(2).WithMessage(customer => $"The First Name cant be empty, more than 50 character or less than 2 characters. {customer.FirstName} is not valid.");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).MinimumLength(2).WithMessage(customer => $"The Last Name cant be empty, more than 50 character or less than 2 characters. {customer.LastName} is not valid.");
            RuleFor(x => x.TeleNumber).NotEmpty().Matches(telephoneRegex).WithMessage(customer => $"{customer.TeleNumber} is not a valid UK landline number.");
            RuleFor(x => x.MobNumber).NotEmpty().Matches(mobRegex).WithMessage(customer => $"{customer.MobNumber} is not a valid UK mobile number.");
            RuleFor(x => x.Address1).NotEmpty().WithMessage(customer => $"The First Line Of the Address cant be empty {customer.Address1}.");
            RuleFor(x => x.Address2).NotEmpty().WithMessage(customer => $"The Second Line Of the Address cant be empty {customer.Address2}.");
            RuleFor(x => x.Town).NotEmpty().MaximumLength(50).WithMessage(customer => $"{customer.Town} is more than 50 characters. Please enter correct UK town.");
            RuleFor(x => x.Postcode).NotEmpty().Matches(postcodeRegex).WithMessage(customer => $"{customer.Postcode} is not a valid Postcode. Please enter a valid Postcode");
            //RuleFor(x => x.User).NotEmpty().WithMessage("Users Details must be provided");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(customer => $"{customer.Email} is not a valid email address. Please enter a valid email address.");
        }
    }
}
