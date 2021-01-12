using FluentValidation;
using System.Linq;

namespace SpaceApp.Models.Register
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        private UserContext _context;
        public RegisterValidator(UserContext context)
        {
            _context = context;
            RuleFor(x => x.IdNumber).NotEmpty().WithMessage("IdNumber cannot be empty");
            RuleFor(x => x.IdNumber).Length(11).WithMessage("IdNumber must contain exactly 11 digits");
            RuleFor(x => x.IdNumber).Must(NotUsedIdNumber).WithMessage("This IdNumber is already used");
            
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Username).Must(NotUsedUsername).WithMessage("This Username is already used");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Passowrd cannot be empty");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Minimum length of the Passoword must be 8 characters");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be empty");
            RuleFor(x => x.IsMarried).NotNull().WithMessage("IsMarried field is mandatory");

            RuleFor(x => x.IsWorker).NotNull().WithMessage("IsWorker field is mandatory"); 
            RuleFor(x => x.Salary).NotNull().When(u => u.IsWorker == true).WithMessage("Salary field is mandatory when user is worker");

        }
        private bool NotUsedIdNumber(string idNumber)
        {
            if (_context.Users.Any(x => x.IdNumber.Equals(idNumber)))
            {
                return false;
            }
            return true;
        }

        private bool NotUsedUsername(string username)
        {
            if (_context.Users.Any(x => x.Username.Equals(username)))
            {
                return false;
            }
            return true;
        }
    }
}
