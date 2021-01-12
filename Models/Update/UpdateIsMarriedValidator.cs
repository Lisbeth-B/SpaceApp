using FluentValidation;

namespace SpaceApp.Models.Update
{
    public class UpdateIsMarriedValidator : AbstractValidator<UpdateIsMarriedModel>
    {
        public UpdateIsMarriedValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.IsMarried).NotNull();
        }
    }
}
