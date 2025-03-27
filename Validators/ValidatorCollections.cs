using FluentValidation;
using FluentValidation.AspNetCore;

namespace LearningVocab.Validators
{
    public static class ValidatorCollections
    {
        public static void AddValidatorCollections(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();
        }
    }
}
