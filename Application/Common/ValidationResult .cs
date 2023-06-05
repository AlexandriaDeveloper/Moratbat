

namespace Application.Common
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
                "ValidationError",
                "A validation problem occurred.");

        Error[] Errors { get; }
    }

    public class ValidationResult : Result, IValidationResult
    {
        private ValidationResult(Error[] errors)
             : base(false, IValidationResult.ValidationError) =>
             Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
    public class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        private ValidationResult(Error[] errors)
               : base(default, false, IValidationResult.ValidationError) =>
               Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
    }
}