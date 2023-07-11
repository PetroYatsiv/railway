using System.ComponentModel.DataAnnotations;

namespace TrainComponent.Application.Exceptions
{
    public class ValidationException : Exception
    {
        private FluentValidation.Results.ValidationResult validationResult;

        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
           ValidationErrors = validationResult.MemberNames.ToList();
        }

        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            this.validationResult = validationResult;
        }
    }
}
