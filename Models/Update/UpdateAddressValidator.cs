using FluentValidation;

namespace SpaceApp.Models.Update
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressModel>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
