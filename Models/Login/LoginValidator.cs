using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApp.Models
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator(UserContext context)
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
