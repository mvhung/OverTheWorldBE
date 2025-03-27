using FluentValidation;
using LearningVocab.DTO;

namespace LearningVocab.Validators
{
    public class UserValidator : AbstractValidator<CreateUserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }
    }
}
