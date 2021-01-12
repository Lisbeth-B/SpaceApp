using FluentValidation;

namespace SpaceApp.Models.Update
{
    public class UpdateIsWorkerValidator : AbstractValidator<UpdateIsWorkerModel>
    {
        public UpdateIsWorkerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.IsWorker).NotNull();
            RuleFor(x => x.Salary).NotEmpty().When(u => u != null && u.IsWorker == true);
        }
    }
}
